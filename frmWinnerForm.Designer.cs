namespace XO_Game_Project
{
    partial class frmWinnerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCestitka = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Orbitron", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Congratulations!";
            // 
            // lblCestitka
            // 
            this.lblCestitka.BackColor = System.Drawing.Color.Transparent;
            this.lblCestitka.Font = new System.Drawing.Font("Orbitron", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCestitka.Location = new System.Drawing.Point(12, 121);
            this.lblCestitka.Name = "lblCestitka";
            this.lblCestitka.Size = new System.Drawing.Size(462, 61);
            this.lblCestitka.TabIndex = 1;
            this.lblCestitka.Text = "Halil WON";
            this.lblCestitka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmWinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::XO_Game_Project.Properties.Resources.WinnerForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(486, 236);
            this.Controls.Add(this.lblCestitka);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmWinnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Congratulations";
            this.Load += new System.EventHandler(this.frmWinnerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWinnerForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCestitka;
    }
}