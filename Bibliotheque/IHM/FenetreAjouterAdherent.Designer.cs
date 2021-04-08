
namespace Bibliotheque.IHM
{
    partial class FenetreAjouterAdherent
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
            this.btn_Annuler = new System.Windows.Forms.Button();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.tbx_Nom = new System.Windows.Forms.TextBox();
            this.lab_Nom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Location = new System.Drawing.Point(189, 75);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuler.TabIndex = 7;
            this.btn_Annuler.Text = "Annuler";
            this.btn_Annuler.UseVisualStyleBackColor = true;
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(26, 75);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(75, 23);
            this.btn_Valider.TabIndex = 8;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // tbx_Nom
            // 
            this.tbx_Nom.Location = new System.Drawing.Point(79, 32);
            this.tbx_Nom.Name = "tbx_Nom";
            this.tbx_Nom.Size = new System.Drawing.Size(160, 20);
            this.tbx_Nom.TabIndex = 6;
            // 
            // lab_Nom
            // 
            this.lab_Nom.AutoSize = true;
            this.lab_Nom.Location = new System.Drawing.Point(38, 35);
            this.lab_Nom.Name = "lab_Nom";
            this.lab_Nom.Size = new System.Drawing.Size(29, 13);
            this.lab_Nom.TabIndex = 5;
            this.lab_Nom.Text = "Nom";
            // 
            // FenetreAjouterAdherent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 130);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.tbx_Nom);
            this.Controls.Add(this.lab_Nom);
            this.Name = "FenetreAjouterAdherent";
            this.Text = "FenetreAjouterAdherent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Annuler;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.TextBox tbx_Nom;
        private System.Windows.Forms.Label lab_Nom;
    }
}