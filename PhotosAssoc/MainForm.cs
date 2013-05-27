using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;

namespace PhotosAssoc
{
    public partial class MainForm : Form
    {
        Regex dirNamePattern = new Regex(@"\\(\d{3,})[^\\]*$");
        Regex jpegFileExtensionPattern = new Regex(".jpe?g$", RegexOptions.IgnoreCase);
        Regex photoNamePattern = new Regex(@"([\d_]*).jpg$");

        public MainForm()
        {
            InitializeComponent();
        }

        private void cmdMakeArchive_Click(object sender, EventArgs e)
        {
            string tmpDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tmpDir);

            var dirs = Directory.EnumerateDirectories(txtPhotosPath.Text);

            foreach (var dir in dirs) {
                var match = dirNamePattern.Match(dir);
                if(match.Groups.Count == 2) {
                    var id = match.Groups[1].Value;
                    var files = Directory.EnumerateFiles(dir);

                    var i = 0;
                    foreach (var file in files) {
                        if(jpegFileExtensionPattern.IsMatch(Path.GetFileName(file)))
                        {
                            File.Copy(file, Path.Combine(tmpDir, string.Format("{0}_{1}.jpg", id, ++i)));
                        }
                    }
                }
            }

            File.Delete(Path.Combine(txtPhotosPath.Text, txtArciveName.Text));


            try {
                Process zipProcess = new Process();
                zipProcess.StartInfo.FileName = "7za.exe";
                zipProcess.StartInfo.Arguments = string.Format(@"a -tzip ""{0}"" ""{1}\*""", Path.Combine(txtPhotosPath.Text, txtArciveName.Text), tmpDir);
                zipProcess.StartInfo.CreateNoWindow = true;
                zipProcess.Start();
                zipProcess.WaitForExit();
            } catch(Exception ex) {
                MessageBox.Show("7za archivator not found.");
            }            

            Directory.Delete(tmpDir, true);
        }

        private void cmdPhotosPathBrowse_Click(object sender, EventArgs e)
        {
            if(photosDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtPhotosPath.Text = photosDialog.SelectedPath;
        }

        private void cmdXmlBrowse_Click(object sender, EventArgs e)
        {
            if (xmlDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtXmlPath.Text = xmlDialog.SelectedPath;
        }

        private void cmdUpdateXML_Click(object sender, EventArgs e)
        {
            string report = "";
            try {
                Process zipProcess = new Process();
                zipProcess.StartInfo.FileName = "7za.exe";
                zipProcess.StartInfo.Arguments = string.Format(@"l ""{0}""", Path.Combine(txtPhotosPath.Text, txtArciveName.Text));
                zipProcess.StartInfo.CreateNoWindow = true;
                zipProcess.StartInfo.RedirectStandardOutput = true;
                zipProcess.StartInfo.UseShellExecute = false;
                
                zipProcess.Start();

                report = zipProcess.StandardOutput.ReadToEnd();

                zipProcess.WaitForExit();
            } catch (Exception ex) {
                MessageBox.Show("7za archivator not found.");
                return;
            }

            var reportLines = report.Split('\n');

            //List<string> photos = new List<string>();

            Dictionary<int, List<string>> assocPhotos = new Dictionary<int, List<string>>();

            for (int i = 12; i < reportLines.Count() - 3; ++i) {
                string line = reportLines[i].Trim();
                var match = photoNamePattern.Match(line);
                if (match.Groups.Count == 2) {

                    string fileName = match.Groups[1].Value.Trim();

                    int id = int.Parse(fileName.Split('_')[0]);

                    if (!assocPhotos.ContainsKey(id))
                        assocPhotos[id] = new List<string>();
                        
                    assocPhotos[id].Add(fileName);
                }
            }

            updateXml(assocPhotos);
        }

        private void updateXml(Dictionary<int, List<string>> assocPhotos)
        {
            var files = Directory.GetFiles(txtXmlPath.Text);

            string outPath = Path.Combine(txtXmlPath.Text, "WithPhotos\\");
            Directory.CreateDirectory(outPath);

            foreach (var file in files) {
                if (file.ToLower().EndsWith(".xml")) {
                    var doc = new XmlDocument();
                    doc.Load(file);

                    var rowData = doc.DocumentElement.GetElementsByTagName("ROWDATA");

                    if (rowData.Count == 1) {
                        int index = 0;
                        var rowDataElement = rowData[0];

                        var rowCount = rowDataElement.ChildNodes.Count;

                        for (int i = 0; i < rowCount; ++i) {
                            
                            var line = rowDataElement.ChildNodes[i];

                            var id = line.Attributes["RLT_MAIN_ID"].Value;
                            id = id.Substring(0, id.Length - 5);
                            int iid = int.Parse(id);
                            
                            var attr = doc.CreateAttribute("RLT_PHOTOS");
                            attr.Value = "";

                            if (assocPhotos.ContainsKey(iid)) {
                                assocPhotos[iid].ForEach(str => attr.Value += str + ";");
                            }

                            line.Attributes.Append(attr);
                        }
                    }

                    doc.Save(Path.Combine(outPath, Path.GetFileName(file)));
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtPhotosPath.Text = Properties.Settings.Default.photospath;
            txtXmlPath.Text = Properties.Settings.Default.xmlpath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.photospath = txtPhotosPath.Text;
            Properties.Settings.Default.xmlpath = txtXmlPath.Text;
            Properties.Settings.Default.Save();
        }

        private void txtPhotosPath_TextChanged(object sender, EventArgs e)
        {
            photosDialog.SelectedPath = this.Text;
        }

        private void txtXmlPath_TextChanged(object sender, EventArgs e)
        {
            xmlDialog.SelectedPath = this.Text;
        }
    }
}
