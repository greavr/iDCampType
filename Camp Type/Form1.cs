using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;  
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Camp_Type
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List Programs in Combobox
            try
            {
                string[,] iDPrograms = Programs();
                for (int i = 0; i < (iDPrograms.Length / 4); i++)
                {
                    cbCourses.Items.Add(iDPrograms[i, 0]);
                }
            }
            catch
            {
                MessageBox.Show("Error XML File not found, please press options and find the XML file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public string[,] Programs()
        {
            try
            {
                //1 = Program Name
                //2 = WallPaper
                //3 = Images
                //4 = Start Menu
                //5 = Icon

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(Camp_Type.Properties.Settings.Default.XMLFile);

                XmlNodeList xName = xDoc.GetElementsByTagName("name");
                XmlNodeList xWallPaper = xDoc.GetElementsByTagName("wallpaper");
                XmlNodeList xImages = xDoc.GetElementsByTagName("images");
                XmlNodeList xStartmenu = xDoc.GetElementsByTagName("startmenu");
                XmlNodeList xIcon = xDoc.GetElementsByTagName("icon");


                string[,] result = new string[xName.Count, 4];
                for (int i = 0; i < xName.Count; i++)
                {
                    result[i, 0] = xName[i].InnerText.ToString();
                    result[i, 1] = xWallPaper[i].InnerText.ToString();
                    result[i, 2] = xImages[i].InnerText.ToString();
                    result[i, 3] = xStartmenu[i].InnerText.ToString();
                    result[i, 4] = xIcon[i].InnerText.ToString();
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[,] result = new string[1,1];
                result[0,0] = "error";
                return result;
            }
        }

        private void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCourses.SelectedIndex != -1)
            {
                btnSubmit.Enabled = true;
            }
        }

        private void llblOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Options frmOpt = new Options();
            frmOpt.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Hide Status Box
            lblResult.Text = "Complete";
            lblResult.Visible = false;
            Application.DoEvents();


            //Check the combobox for course selected and set the values
            string Startmenu = "";
            string Images = "";
            string Wallpaper = "";
            string IconPath = "";
            bool found = false;

            string[,] iDPrograms = Programs();
            for (int i = 0; i < (iDPrograms.Length / 4); i++)
            {
                if (cbCourses.Text == iDPrograms[i, 0])
                {
                    Wallpaper = iDPrograms[i, 1];
                    Images = iDPrograms[i, 2];
                    Startmenu = iDPrograms[i, 3];
                    IconPath = iDPrograms[i, 4];
                    found = true;
                    break;
                }
             }

            //if found lets roll
            if (found)
            {
                CampType aType = new CampType(Wallpaper, Startmenu, Images,IconPath);
                try
                {
                    aType.SetMachine();
                    lblResult.Visible = true;
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.ToString());
                    lblResult.Text = "FAILURE, OH THE HORROR";
                    lblResult.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Error", "Camp Type Not Found");
            }

        }

    }
}
