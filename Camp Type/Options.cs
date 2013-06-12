using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camp_Type
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void btnXMLBrowse_Click(object sender, EventArgs e)
        {
            ofdXML.ShowDialog();
        }

        private void ofdXML_FileOk(object sender, CancelEventArgs e)
        {
            txtXML.Text = ofdXML.FileName.ToString();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            txtXML.Text = Camp_Type.Properties.Settings.Default.XMLFile.ToString();
            ofdXML.InitialDirectory = Camp_Type.Properties.Settings.Default.XMLFile.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Camp_Type.Properties.Settings.Default.XMLFile = txtXML.Text;
            Properties.Settings.Default.Save();
            Application.Restart();
            this.Close();

        }

        private void txtXML_TextChanged(object sender, EventArgs e)
        {
            if ((txtXML.Text != Camp_Type.Properties.Settings.Default.XMLFile) && (txtXML.Text.IndexOf(".xml") != -1))
            {
                btnApply.Enabled = true;
            }
            else
            {
                btnApply.Enabled = false;
            }
        }
    }
}
