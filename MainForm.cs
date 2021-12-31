using System;
using System.Windows.Forms;
using System.IO;

namespace DDSInjector
{
    using Properties;
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = "DDS Injector v" + GetType().Assembly.GetName().Version.ToString(3);

            string[] args = Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (arg.EndsWith(".dds", true, null) && File.Exists(arg))
                {
                    Settings.Default.ddsPath = arg;
                    Settings.Default.Save();
                }
            }

            openFileDialog.Filter = "DDS File (*.dds)|*.dds";
            ddsFileTextBox.Text      = Settings.Default.ddsPath;
            rootFolderTextBox.Text   = Settings.Default.rootPath;
            exportFolderTextBox.Text = Settings.Default.exportPath;

        }

        private struct DDSHeader
        {
            public int headerSize;
            public bool isDX10;
            public string format;

            public int dwMagic;
            public int dwSize;
            public int dwFlags;
            public int dwHeight;
            public int dwWidth;
            public int dwPitchOrLinearSize;
            public int dwDepth;
            public int dwMipMapCount;
            //DDS_PIXELFORMAT->
            public int dwPixelSize;
            public int dwPixelFlags;
            public int dwPixelFourCC;
            public int dwPixelRGBBitCount;
            public int dwPixelRBitMask;
            public int dwPixelGBitMask;
            public int dwPixelBBitMask;
            public int dwPixelABitMask;
            //<-DDS_PIXELFORMAT
            public int dwCaps;
            public int dwCaps2;
            public int dwCaps3;
            public int dwCaps4;
        }

        private DDSHeader ddsHeader = new();

        private bool GetDDSHeader(string filename)
        {
            try
            {
                ddsHeader.isDX10 = false;

                using BinaryReader reader = new(File.OpenRead(filename));

                ddsHeader.dwMagic = reader.ReadInt32();
                ddsHeader.dwSize = reader.ReadInt32();
                ddsHeader.dwFlags = reader.ReadInt32();
                ddsHeader.dwHeight = reader.ReadInt32();
                ddsHeader.dwWidth = reader.ReadInt32();
                ddsHeader.dwPitchOrLinearSize = reader.ReadInt32();
                ddsHeader.dwDepth = reader.ReadInt32();
                ddsHeader.dwMipMapCount = reader.ReadInt32();
                reader.ReadBytes(44); //dwReserved1
                //DDS_PIXELFORMAT->
                ddsHeader.dwPixelSize = reader.ReadInt32();
                ddsHeader.dwPixelFlags = reader.ReadInt32();
                ddsHeader.dwPixelFourCC = reader.ReadInt32();
                ddsHeader.dwPixelRGBBitCount = reader.ReadInt32();
                ddsHeader.dwPixelRBitMask = reader.ReadInt32();
                ddsHeader.dwPixelGBitMask = reader.ReadInt32();
                ddsHeader.dwPixelBBitMask = reader.ReadInt32();
                ddsHeader.dwPixelABitMask = reader.ReadInt32();
                //<-DDS_PIXELFORMAT
                ddsHeader.dwCaps = reader.ReadInt32();
                ddsHeader.dwCaps2 = reader.ReadInt32();
                ddsHeader.dwCaps3 = reader.ReadInt32();
                ddsHeader.dwCaps4 = reader.ReadInt32();

                // If the DDS_PIXELFORMAT dwFlags is set to DDPF_FOURCC (0x4) and dwFourCC is set to "DX10" (0x30315844) an additional DDS_HEADER_DXT10 structure will be present
                ddsHeader.isDX10 = (ddsHeader.dwPixelFlags == 0x4 && ddsHeader.dwPixelFourCC == 0x30315844);
                if (ddsHeader.isDX10)
                {
                    return false;
                }

                ddsHeader.format = "";
                ddsHeader.format += (char)(ddsHeader.dwPixelFourCC & 0xFF);
                ddsHeader.format += (char)(ddsHeader.dwPixelFourCC >> 8 & 0xFF);
                ddsHeader.format += (char)(ddsHeader.dwPixelFourCC >> 16 & 0xFF);
                ddsHeader.format += (char)(ddsHeader.dwPixelFourCC >> 24 & 0xFF);

                // Size of dwMagic + announced size
                ddsHeader.headerSize = 4 + ddsHeader.dwSize;
            }
            catch { return false; }

            return true;
        }

        private static string GetUexpFormat(string filename)
        {
            try
            {
                using BinaryReader r = new(File.OpenRead(filename));

                string format = "";
                while (r.BaseStream.Position < r.BaseStream.Length)
                {
                    int c = r.ReadByte();
                    if (c == 0x40) //@
                    {
                        r.ReadInt32();
                        if (r.PeekChar() != 'P') continue;

                        while (r.PeekChar() != 0)
                        {
                            format += r.ReadChar();
                        }

                        return format.Remove(0, 3);
                    }
                }
            }
            catch { }
            return null;
        }

        private void UpdateStatus()
        {
            if (!Visible) return;

            statusLabel.Text = "";
            injectButton.Enabled = false;
            dataGridView.Rows.Clear();

            if (String.IsNullOrEmpty(Settings.Default.ddsPath))
            {
                statusLabel.Text = "Please select a DDS file to inject";
                return;
            }
            if(!File.Exists(Settings.Default.ddsPath))
            {
                statusLabel.Text = "DDS file not found. Please select a DDS file to inject";
                return;
            }
            if (String.IsNullOrEmpty(Settings.Default.rootPath))
            {
                statusLabel.Text = "Please select the root folder";
                return;
            }
            if (!Directory.Exists(Settings.Default.rootPath))
            {
                statusLabel.Text = "Root directory not found. Please select the root folder";
                return;
            }
            if (String.IsNullOrEmpty(Settings.Default.exportPath))
            {
                statusLabel.Text = "Please select the export folder";
                return;
            }

            if(!GetDDSHeader(Settings.Default.ddsPath))
            {
                if(ddsHeader.isDX10)
                {
                    statusLabel.Text = "❌DXT10 DDS format not supported";
                }
                else
                {
                    statusLabel.Text = "❌Unable to read DDS correctly";
                }
                return;
            }

            /*if(ddsHeader.dwHeight != ddsHeader.dwWidth)
            {
                statusLabel.Text = "❌Non square texture not supported";
                return;
            }*/

            int ubulkSize = ddsHeader.dwPitchOrLinearSize + ddsHeader.dwPitchOrLinearSize / 4;
            string ddsFilename = Path.GetFileNameWithoutExtension(Settings.Default.ddsPath);

            try
            {
                string[] allfiles = Directory.GetFiles(Settings.Default.rootPath, "*.ubulk", SearchOption.AllDirectories);
                foreach (string file in allfiles)
                {
                    try
                    {
                        // Making sure the formats matches
                        string uexpFile = Path.ChangeExtension(file, ".uexp");
                        if (!File.Exists(uexpFile)) continue;
                        string format = GetUexpFormat(uexpFile);
                        if (hideFormats.Checked && (string.IsNullOrEmpty(format) || !ddsHeader.format.StartsWith(format))) continue;

                        FileInfo info = new(file);
                        if (info.Length == ubulkSize)
                        {
                            string name = Path.GetFileNameWithoutExtension(file);
                            int i = dataGridView.Rows.Add(name, format, Path.GetDirectoryName(file));

                            if (ddsFilename.Contains(name))
                            {
                                dataGridView.Rows[i].Selected = true;
                                statusLabel.Text = "✔Matching file name found";
                            }
                        }
                    }
                    catch { }
                }
                if(dataGridView.Rows.Count == 0)
                {
                    statusLabel.Text = "❌Unable to find compatible asset. Make sure the root folder is correct.";
                }
                else
                {
                    injectButton.Enabled = true;
                    injectButton.Focus();
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "❌Error while looking for compatible assets: "+ex.Message;
                return;
            }
        }

        private void ddsFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = Settings.Default.ddsPath;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ddsFileTextBox.Text = Settings.Default.ddsPath = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }

        private void rootFolderButton_Click(object sender, EventArgs e)
        {
            rootFolderBrowser.SelectedPath = Settings.Default.rootPath;
            DialogResult result = rootFolderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                rootFolderTextBox.Text = Settings.Default.rootPath = rootFolderBrowser.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void exportFolderButton_Click(object sender, EventArgs e)
        {
            exportFolderBrowser.SelectedPath = Settings.Default.exportPath;
            DialogResult result = exportFolderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                exportFolderTextBox.Text = exportFolderBrowser.SelectedPath;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            statusLabel.Text = "";
        }

        private void injectButton_Click(object sender, EventArgs e)
        {
            injectButton.Enabled = false;

            try
            {
                string rootDir = Path.GetDirectoryName(Settings.Default.rootPath);
                string selectedAsset = (string)dataGridView.SelectedRows[0].Cells[2].Value + Path.DirectorySeparatorChar + (string)dataGridView.SelectedRows[0].Cells[0].Value;
                string target = Settings.Default.exportPath + selectedAsset.Remove(0, rootDir.Length);

                Directory.CreateDirectory(Path.GetDirectoryName(target));

                string dds = Settings.Default.ddsPath;
                BinaryReader reader = new(File.OpenRead(dds));

                
                string ubulkSrc = selectedAsset + ".ubulk";
                string ubulkDst = target + ".ubulk";

                string uexpSrc = selectedAsset + ".uexp";
                string uexpDst = target + ".uexp";

                int uexpHeaderSize = 0;
                string wantedFormat = "";
                try
                {
                    using BinaryReader r = new(File.OpenRead(uexpSrc));

                    while (r.BaseStream.Position < r.BaseStream.Length)
                    {
                        int c = r.ReadByte();

                        if (c == 0x40) //@
                        {
                            int o = r.ReadInt32();
                            if (r.PeekChar() != 'P') continue;

                            uexpHeaderSize = (int)r.BaseStream.Position + o + 44;

                            while (r.PeekChar() != 0)
                            {
                                wantedFormat += r.ReadChar();
                            }

                            wantedFormat = wantedFormat.Remove(0, 3);
                            break;
                        }
                    }
                }
                catch { }

                if (uexpHeaderSize == 0)
                {
                    statusLabel.Text = "❌Couldn't get uexp header size";
                    return;
                }

                if(!ddsHeader.format.StartsWith(wantedFormat))
                {
                    string message = "Wrong DDS Format detected. Wanted " + wantedFormat + " got " + ddsHeader.format + ".\n\nContinue the injection anyway?";
                    DialogResult result = MessageBox.Show(message , "Continue the injection?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        statusLabel.Text = "❌Injection aborted";
                        injectButton.Enabled = true;
                        return;
                    }
                }

                //
                // Creating .ubulk
                //
                File.Copy(ubulkSrc, ubulkDst, true);
                BinaryWriter writer = new(File.OpenWrite(ubulkDst));

                int bytesToInject= ddsHeader.dwPitchOrLinearSize + ddsHeader.dwPitchOrLinearSize / 4;

                // Skip dds header
                reader.BaseStream.Seek(ddsHeader.headerSize, 0);
                // Write 2 biggest textures
                writer.Write(reader.ReadBytes(bytesToInject));
                writer.Close();

                //
                // Creating .uexp
                //
                File.Copy(uexpSrc, uexpDst, true);
                writer = new(File.OpenWrite(uexpDst));

                // Skip uexp header
                writer.BaseStream.Seek(uexpHeaderSize, 0);

                for (int n = ddsHeader.dwMipMapCount -2; n > 0; n--)
                {
                    bytesToInject /= 4;
                    writer.Write(reader.ReadBytes(bytesToInject));

                    if (n == 3)
                    {
                        // Inject 4a and 4b
                        writer.Write(reader.ReadBytes(bytesToInject + bytesToInject));
                        n -= 2;
                    }
                }

                /*int count = 0;
                for (int size = ddsHeader.dwHeight / 4; size >= 4; size /= 2)
                {
                    bytesToInject /= 4;
                    writer.Write(reader.ReadBytes(bytesToInject));

                    if(size == 4)
                    {
                        // Inject 4a and 4b
                        writer.Write(reader.ReadBytes(bytesToInject + bytesToInject));
                    }
                    count++;
                }*/
                writer.Close();
                reader.Close();

                statusLabel.Text = "✔Files injected succesfully";
            }
            catch(Exception ex)
            {
                statusLabel.Text = "❌Error while injecting : " + ex.Message;
            }

            injectButton.Enabled = true;
        }

        private void exportFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.exportPath = exportFolderTextBox.Text;
            Settings.Default.Save();
            if (string.IsNullOrEmpty(exportFolderTextBox.Text))
            {
                statusLabel.Text = "Please select the export folder";
            }
            else if (dataGridView.RowCount == 0)
            {
                UpdateStatus();
            }
        }

        private void rootFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.rootPath = rootFolderTextBox.Text;
            Settings.Default.Save();
            UpdateStatus();
        }

        private void ddsFileTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ddsPath = ddsFileTextBox.Text;
            Settings.Default.Save();
            UpdateStatus();
        }

        private void hideFormats_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
    }
}
