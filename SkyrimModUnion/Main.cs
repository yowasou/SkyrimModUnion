using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpCompress.Archive.Zip;
using SharpCompress.Common;
using SharpCompress.Reader;
using SharpCompress.Writer;

namespace SkyrimModUnion
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter =
                "ZIP,RAR,7z|*.zip;*.rar;*.7z;*.7zip|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string f in ofd.FileNames)
                {
                    AddLstFiles(f);
                }
            }
        }

        protected virtual void AddLstFiles(string f)
        {
            if (!lstFiles.Items.Contains(f))
            {
                lstFiles.Items.Add(f);
            }
        }

        private void btnOutSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter =
                "ZIP|*.zip|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "ZIPファイルの出力先を選択してください";
            sfd.RestoreDirectory = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtOutPath.Text = sfd.FileName;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChangeControlEnables(false);
            bW.RunWorkerAsync();
        }

        protected virtual void ChangeControlEnables(bool b)
        {
            lstFiles.Enabled = b;
            button1.Enabled = b;
            btnDelete.Enabled = b;
            txtOutPath.Enabled = b;
            btnOutSelect.Enabled = b;
            btnOutput.Enabled = b;
        }

        protected virtual void OutputFile()
        {
            //各ファイルを解凍
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string temppath = path + "\\temp";
            if (Directory.Exists(temppath))
            {
                Directory.Delete(temppath, true);
            }
            string extTemppath = temppath + "\\ext";
            string cmpTemppath = temppath + "\\cmp";
            Directory.CreateDirectory(cmpTemppath);
            bW.ReportProgress(10);
            foreach (object o in lstFiles.Items)
            {
                string file = Convert.ToString(o);
                string ext = Path.GetExtension(file).ToLower();
                ExtractFile(extTemppath, file, ext);
                //espファイルと、espファイルと同階層のファイル、フォルダをcmpへコピー
                List<string> copyOrgPath = new List<string>();
                foreach (string s in Directory.GetFiles(extTemppath
                    , "*.esp", SearchOption.AllDirectories))
                {
                    string espPath = Path.GetDirectoryName(s);
                    if (!copyOrgPath.Contains(espPath))
                    {
                        copyOrgPath.Add(espPath);
                    }
                }
                foreach (string s in copyOrgPath)
                {
                    CopyDirectory(s, cmpTemppath);
                }
            }
            bW.ReportProgress(50);
            //cmpフォルダを圧縮
            using (var zip = File.OpenWrite(txtOutPath.Text))
            {
                using (var zipWriter = WriterFactory.Open(zip, ArchiveType.Zip
                    , CompressionType.Deflate))
                {
                    zipWriter.WriteAll(cmpTemppath, "*", SearchOption.AllDirectories);
                }
            }
            bW.ReportProgress(100);
        }
        /// <summary>
        /// ディレクトリをコピーする
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        public static void CopyDirectory(
            string sourceDirName, string destDirName)
        {
            //コピー先のディレクトリがないときは作る
            if (!System.IO.Directory.Exists(destDirName))
            {
                System.IO.Directory.CreateDirectory(destDirName);
                //属性もコピー
                System.IO.File.SetAttributes(destDirName,
                    System.IO.File.GetAttributes(sourceDirName));
            }

            //コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] !=
                    System.IO.Path.DirectorySeparatorChar)
                destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

            //コピー元のディレクトリにあるファイルをコピー
            string[] files = System.IO.Directory.GetFiles(sourceDirName);
            foreach (string file in files)
                System.IO.File.Copy(file,
                    destDirName + System.IO.Path.GetFileName(file), true);

            //コピー元のディレクトリにあるディレクトリについて、
            //再帰的に呼び出す
            string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
                CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
        }
        protected virtual void ExtractFile(string temppath, string file, string ext)
        {
            ReCreateDir(temppath);
            if (ext == ".7z" || ext == ".7zip")
            {
                SevenZManager.fnExtract(file, temppath);
            }
            else
            {
                using (Stream stream = File.OpenRead(file))
                {
                    //未実装：ファイル名にハイフンが入っていたらリネーム
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            reader.WriteEntryToDirectory(temppath
                                , ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                }
            }
        }

        protected virtual void ReCreateDir(string temppath)
        {
            if (Directory.Exists(temppath))
            {
                Directory.Delete(temppath, true);
            }
            Directory.CreateDirectory(temppath);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }

        private void DeleteSelectedItem()
        {
            List<object> deleteObj = new List<object>();
            foreach (object o in lstFiles.SelectedItems)
            {
                deleteObj.Add(o);
            }
            foreach (object o in deleteObj)
            {
                lstFiles.Items.Remove(o);
            }
        }
        private void lstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedItem();
            }
        }

        private void bW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;
        }

        private void bW_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OutputFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                File.AppendAllText(path + "\\errorlog.txt", ex.Message + "\r\n");
                File.AppendAllText(path + "\\errorlog.txt", ex.StackTrace + "\r\n");
                if (ex.InnerException != null)
                {
                    File.AppendAllText(path + "\\errorlog.txt", ex.InnerException.Message + "\r\n");
                    File.AppendAllText(path + "\\errorlog.txt", ex.InnerException.StackTrace + "\r\n");
                }
            }
        }

        private void bW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("出力しました", "出力しました");
            Cursor = Cursors.Default;
            ChangeControlEnables(true);
        }

    }
}
