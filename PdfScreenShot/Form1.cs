using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Acrobat;

namespace PdfScreenShot
{
    public partial class Form1 : Form
    {
        private Thread thread = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (radFile.Checked)
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.FileName = "";
                fd.Filter = "PDF|*.pdf";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = string.Join(";", fd.FileNames);
                }
            }
            else
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fd.SelectedPath;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (thread == null || !thread.IsAlive)
            {
                thread = new Thread(DoWork);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void DoWork()
        {
            string[] strsFiles = GetFiles();
            if (strsFiles.Length > 0)
            {
                int i = 1;
                strsFiles.ToList().ForEach(f =>
                {
                    listMsg.Items.Clear();
                    listMsg.Items.Add($"正在处理第{i}个文件(共{strsFiles.Length}个文件)");
                    string strExportPath = Path.GetDirectoryName(f) + "\\" + Path.GetFileNameWithoutExtension(f);
                    ExportAsImage(f, strExportPath);
                    i++;
                });
                listMsg.Items.Add("完成");
                listMsg.TopIndex = listMsg.Items.Count - 1;
                MessageBox.Show("完成");
            }
        }

        private void ExportAsImage(string strFile, string strExportPath)
        {
            if (!Directory.Exists(strExportPath))
            {
                Directory.CreateDirectory(strExportPath);
            }
            Acrobat.AcroPDDoc pdf = new AcroPDDoc();
            pdf.Open(strFile);

            int pageCount = Convert.ToInt32(txtPage.Text);
            int count = pdf.GetNumPages();
            for (int i = 0; i < count; i++)
            {
                if (i == pageCount)
                    break;
                listMsg.Items.Add($"正在导出第{i + 1}页(共{count}页)");
                listMsg.TopIndex = listMsg.Items.Count - 1;
                int zoom = 1;
                CAcroPDPage page = (CAcroPDPage)pdf.AcquirePage(i);
                CAcroRect pdfRect = (Acrobat.CAcroRect)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");
                CAcroPoint pdfPoint = (Acrobat.CAcroPoint)page.GetSize();
                int imgWidth = (int)((double)pdfPoint.x * zoom);
                int imgHeight = (int)((double)pdfPoint.y * zoom);

                //设置裁剪矩形的大小为当前页的大小  
                pdfRect.Left = 0;
                pdfRect.right = (short)imgWidth;
                pdfRect.Top = 0;
                pdfRect.bottom = (short)imgHeight;
                page.CopyToClipboard(pdfRect, 0, 0, (short)(100 * zoom));
                Object obj = Clipboard.GetData(DataFormats.Bitmap);
                using (Bitmap bitmap = (Bitmap)obj)
                {
                    SavePicture(bitmap, strExportPath, Path.GetFileNameWithoutExtension(strFile), (i + 1).ToString());
                }
            }
        }

        private void SavePicture(Bitmap bitmap, string strExportPath, string strFileName, string strPage)
        {
            Size[] size;
            if (bitmap.Width < bitmap.Height)
            {
                size = new Size[] {new Size(721, 1020), new Size(162, 229), new Size(120, 174)};
            }
            else
            {
                if (chkKuanPing.Checked)
                {
                    size = new Size[] { new Size(721, 405), new Size(210, 117), new Size(120, 67) };
                }
                else
                {
                    size = new Size[] { new Size(721, 540), new Size(210, 117), new Size(120, 89) };
                } 
            }
            string strBig = $@"{strExportPath}\{strFileName}_{strPage}.jpg";
            using (Bitmap bt = new Bitmap(bitmap, size[0]))
            {
                bt.Save(strBig, ImageFormat.Jpeg);
            }
            if (strPage == "1")
            {
                string strMidele = $@"{strExportPath}\m_{strFileName}_1.jpg";
                using (Bitmap bt = new Bitmap(bitmap, size[1]))
                {
                    bt.Save(strMidele, ImageFormat.Jpeg);
                }
            }
            string strSmall = $@"{strExportPath}\1_{strFileName}_{strPage}.jpg";
            using (Bitmap bt = new Bitmap(bitmap, size[2]))
            {
                bt.Save(strSmall, ImageFormat.Jpeg);
            }
        }

        private string[] GetFiles()
        {
            if (txtPath.Text.Contains(";"))
            {
                return txtPath.Text.Split(';');
            }
            else
            {
                if (Directory.Exists(txtPath.Text))
                {
                    return Directory.GetFiles(txtPath.Text, "*.pdf");
                }
                else if (File.Exists(txtPath.Text))
                {
                    return new string[1] {txtPath.Text};
                }
            }
            return new string[0];
        }
    }
}
