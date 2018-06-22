using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jbinput
{
    public partial class Form1 : Form
    {

        public static List<zbox> zboxlist = new List<zbox>();

        public Form1()
        {
            InitializeComponent();
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strFileName = ofd.FileName;
                //其他代码


                StreamReader sr = new StreamReader(strFileName, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line.ToString());
                }


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            String temp = "<?xml version=1.0 encoding=utf-8> <buddylist> <group>";



            foreach (string s in listBox1.Items)
            {
                string[] sss = s.Split(',');
              //  zboxlist.Add( new zbox { gname = sss[0], uname = sss[1], fname = sss[2] });

                temp = temp + "< gname >" + sss[0] + "</gname><user>";
                temp = temp + "< uname >" + sss[1] + "</ uname >";
                temp = temp + "< fname >" + sss[2] + "</ fname ></user>";


            }

            temp = temp + "</ group > </ buddylist >";





                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "";
                sfd.InitialDirectory = @"C:\";
                sfd.Filter = "XML文件| *.xml";
                sfd.ShowDialog();

                string path = sfd.FileName;
                if (path == "")
                {
                    return;
                }

                using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(temp);
                    fsWrite.Write(buffer, 0, buffer.Length);
                    MessageBox.Show("保存成功");

                }



                
          


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.csdn.net/ot512csdn/article/details/80778142");
        }
    }

    public class zbox
    {

        public string gname { get; set; }
        public string uname { get; set; }
        public string fname { get; set; }

    }


}
