using System;
using System.Collections.Generic;
using System.Linq;
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
            string outputDir = txtOutputPhotosDir.Text;
            Directory.CreateDirectory(outputDir);

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
                            File.Copy(file, Path.Combine(outputDir, string.Format("{0}_{1}.jpg", id, ++i)));
                        }
                    }
                }
            }
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
            Dictionary<int, List<string>> assocPhotos = new Dictionary<int, List<string>>();

            var files = Directory.EnumerateFiles(txtOutputPhotosDir.Text);
            foreach(var fullFileName in files) {
                string file = Path.GetFileName(fullFileName);

                var match = photoNamePattern.Match(file);
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
                                assocPhotos[iid].ForEach(str => attr.Value += string.Format(@"http://agency40.ru/files/xml/photos/{0}.jpg;", str));
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
            txtOutputPhotosDir.Text = Properties.Settings.Default.outputpath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.photospath = txtPhotosPath.Text;
            Properties.Settings.Default.xmlpath = txtXmlPath.Text;
            Properties.Settings.Default.outputpath = txtOutputPhotosDir.Text;
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
