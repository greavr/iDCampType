namespace Camp_Type
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblXML = new System.Windows.Forms.Label();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnXMLBrowse = new System.Windows.Forms.Button();
            this.ofdXML = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(200, 46);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(117, 46);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblXML
            // 
            this.lblXML.AutoSize = true;
            this.lblXML.Location = new System.Drawing.Point(13, 13);
            this.lblXML.Name = "lblXML";
            this.lblXML.Size = new System.Drawing.Size(51, 13);
            this.lblXML.TabIndex = 2;
            this.lblXML.Text = "XML File:";
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(70, 10);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(175, 20);
            this.txtXML.TabIndex = 3;
            this.txtXML.TextChanged += new System.EventHandler(this.txtXML_TextChanged);
            // 
            // btnXMLBrowse
            // 
            this.btnXMLBrowse.Location = new System.Drawing.Point(251, 7);
            this.btnXMLBrowse.Name = "btnXMLBrowse";
            this.btnXMLBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnXMLBrowse.TabIndex = 4;
            this.btnXMLBrowse.Text = "...";
            this.btnXMLBrowse.UseVisualStyleBackColor = true;
            this.btnXMLBrowse.Click += new System.EventHandler(this.btnXMLBrowse_Click);
            // 
            // ofdXML
            // 
            this.ofdXML.FileName = "Programs.xml";
            this.ofdXML.Filter = "XML Files|*.xml";
            this.ofdXML.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdXML_FileOk);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 74);
            this.Controls.Add(this.btnXMLBrowse);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.lblXML);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblXML;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnXMLBrowse;
        private System.Windows.Forms.OpenFileDialog ofdXML;
    }
}