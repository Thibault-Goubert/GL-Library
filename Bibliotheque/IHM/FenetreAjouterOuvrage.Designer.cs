
namespace Bibliotheque.IHM
{
    partial class FenetreAjouterOuvrage
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
            this.lab_Auteur = new System.Windows.Forms.Label();
            this.tbx_Auteur = new System.Windows.Forms.TextBox();
            this.tbx_Titre = new System.Windows.Forms.TextBox();
            this.lab_Titre = new System.Windows.Forms.Label();
            this.lbx_AjouterOuvrage_Exemplaires = new System.Windows.Forms.ListBox();
            this.btn_AjouterExemplaire = new System.Windows.Forms.Button();
            this.btn_SupprimerExemplaire = new System.Windows.Forms.Button();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.btn_Annuler = new System.Windows.Forms.Button();
            this.btn_ModifierExemplaire = new System.Windows.Forms.Button();
            this.lab_Etat = new System.Windows.Forms.Label();
            this.tbx_ModifierOuvrageExemplaireEtat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lab_Auteur
            // 
            this.lab_Auteur.AutoSize = true;
            this.lab_Auteur.Location = new System.Drawing.Point(26, 25);
            this.lab_Auteur.Name = "lab_Auteur";
            this.lab_Auteur.Size = new System.Drawing.Size(38, 13);
            this.lab_Auteur.TabIndex = 0;
            this.lab_Auteur.Text = "Auteur";
            // 
            // tbx_Auteur
            // 
            this.tbx_Auteur.Location = new System.Drawing.Point(70, 22);
            this.tbx_Auteur.Name = "tbx_Auteur";
            this.tbx_Auteur.Size = new System.Drawing.Size(100, 20);
            this.tbx_Auteur.TabIndex = 1;
            // 
            // tbx_Titre
            // 
            this.tbx_Titre.Location = new System.Drawing.Point(232, 22);
            this.tbx_Titre.Name = "tbx_Titre";
            this.tbx_Titre.Size = new System.Drawing.Size(100, 20);
            this.tbx_Titre.TabIndex = 3;
            // 
            // lab_Titre
            // 
            this.lab_Titre.AutoSize = true;
            this.lab_Titre.Location = new System.Drawing.Point(198, 25);
            this.lab_Titre.Name = "lab_Titre";
            this.lab_Titre.Size = new System.Drawing.Size(28, 13);
            this.lab_Titre.TabIndex = 2;
            this.lab_Titre.Text = "Titre";
            // 
            // lbx_AjouterOuvrage_Exemplaires
            // 
            this.lbx_AjouterOuvrage_Exemplaires.FormattingEnabled = true;
            this.lbx_AjouterOuvrage_Exemplaires.Location = new System.Drawing.Point(12, 83);
            this.lbx_AjouterOuvrage_Exemplaires.Name = "lbx_AjouterOuvrage_Exemplaires";
            this.lbx_AjouterOuvrage_Exemplaires.Size = new System.Drawing.Size(214, 264);
            this.lbx_AjouterOuvrage_Exemplaires.TabIndex = 4;
            // 
            // btn_AjouterExemplaire
            // 
            this.btn_AjouterExemplaire.Location = new System.Drawing.Point(232, 83);
            this.btn_AjouterExemplaire.Name = "btn_AjouterExemplaire";
            this.btn_AjouterExemplaire.Size = new System.Drawing.Size(116, 23);
            this.btn_AjouterExemplaire.TabIndex = 5;
            this.btn_AjouterExemplaire.Text = "AjouterExemplaire";
            this.btn_AjouterExemplaire.UseVisualStyleBackColor = true;
            this.btn_AjouterExemplaire.Click += new System.EventHandler(this.btn_AjouterExemplaire_Click);
            // 
            // btn_SupprimerExemplaire
            // 
            this.btn_SupprimerExemplaire.Location = new System.Drawing.Point(232, 131);
            this.btn_SupprimerExemplaire.Name = "btn_SupprimerExemplaire";
            this.btn_SupprimerExemplaire.Size = new System.Drawing.Size(116, 23);
            this.btn_SupprimerExemplaire.TabIndex = 6;
            this.btn_SupprimerExemplaire.Text = "SupprimerExemplaire";
            this.btn_SupprimerExemplaire.UseVisualStyleBackColor = true;
            this.btn_SupprimerExemplaire.Click += new System.EventHandler(this.btn_SupprimerExemplaire_Click);
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(12, 353);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(75, 23);
            this.btn_Valider.TabIndex = 7;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Location = new System.Drawing.Point(151, 353);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuler.TabIndex = 8;
            this.btn_Annuler.Text = "Annuler";
            this.btn_Annuler.UseVisualStyleBackColor = true;
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_ModifierExemplaire
            // 
            this.btn_ModifierExemplaire.Location = new System.Drawing.Point(232, 229);
            this.btn_ModifierExemplaire.Name = "btn_ModifierExemplaire";
            this.btn_ModifierExemplaire.Size = new System.Drawing.Size(116, 23);
            this.btn_ModifierExemplaire.TabIndex = 9;
            this.btn_ModifierExemplaire.Text = "ModifierExemplaire";
            this.btn_ModifierExemplaire.UseVisualStyleBackColor = true;
            this.btn_ModifierExemplaire.Click += new System.EventHandler(this.btn_ModifierExemplaire_Click);
            // 
            // lab_Etat
            // 
            this.lab_Etat.AutoSize = true;
            this.lab_Etat.Location = new System.Drawing.Point(252, 187);
            this.lab_Etat.Name = "lab_Etat";
            this.lab_Etat.Size = new System.Drawing.Size(80, 13);
            this.lab_Etat.TabIndex = 10;
            this.lab_Etat.Text = "Exemplaire Etat";
            // 
            // tbx_ModifierOuvrageExemplaireEtat
            // 
            this.tbx_ModifierOuvrageExemplaireEtat.Location = new System.Drawing.Point(232, 203);
            this.tbx_ModifierOuvrageExemplaireEtat.Name = "tbx_ModifierOuvrageExemplaireEtat";
            this.tbx_ModifierOuvrageExemplaireEtat.Size = new System.Drawing.Size(116, 20);
            this.tbx_ModifierOuvrageExemplaireEtat.TabIndex = 11;
            // 
            // FenetreAjouterOuvrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 400);
            this.Controls.Add(this.tbx_ModifierOuvrageExemplaireEtat);
            this.Controls.Add(this.lab_Etat);
            this.Controls.Add(this.btn_ModifierExemplaire);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.btn_SupprimerExemplaire);
            this.Controls.Add(this.btn_AjouterExemplaire);
            this.Controls.Add(this.lbx_AjouterOuvrage_Exemplaires);
            this.Controls.Add(this.tbx_Titre);
            this.Controls.Add(this.lab_Titre);
            this.Controls.Add(this.tbx_Auteur);
            this.Controls.Add(this.lab_Auteur);
            this.Name = "FenetreAjouterOuvrage";
            this.Text = "FenetreAjouterOuvrage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Auteur;
        private System.Windows.Forms.TextBox tbx_Auteur;
        private System.Windows.Forms.TextBox tbx_Titre;
        private System.Windows.Forms.Label lab_Titre;
        private System.Windows.Forms.ListBox lbx_AjouterOuvrage_Exemplaires;
        private System.Windows.Forms.Button btn_AjouterExemplaire;
        private System.Windows.Forms.Button btn_SupprimerExemplaire;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Button btn_Annuler;
        private System.Windows.Forms.Button btn_ModifierExemplaire;
        private System.Windows.Forms.Label lab_Etat;
        private System.Windows.Forms.TextBox tbx_ModifierOuvrageExemplaireEtat;
    }
}