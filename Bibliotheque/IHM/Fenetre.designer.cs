namespace IHM
{
    partial class Fenetre
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
            this.buttonModifierOuvrage = new System.Windows.Forms.Button();
            this.buttonSupprimerOuvrage = new System.Windows.Forms.Button();
            this.listBoxOuvrages = new System.Windows.Forms.ListBox();
            this.listBoxPrets = new System.Windows.Forms.ListBox();
            this.labelPrets = new System.Windows.Forms.Label();
            this.labelOuvrages = new System.Windows.Forms.Label();
            this.listBoxAdherents = new System.Windows.Forms.ListBox();
            this.labelAdherent = new System.Windows.Forms.Label();
            this.buttonAjouterAdherent = new System.Windows.Forms.Button();
            this.buttonModifierAdherent = new System.Windows.Forms.Button();
            this.buttonSupprimerAdherent = new System.Windows.Forms.Button();
            this.buttonAjouterOuvrage = new System.Windows.Forms.Button();
            this.listBoxExemplaires = new System.Windows.Forms.ListBox();
            this.labelExemplaires = new System.Windows.Forms.Label();
            this.buttonEmprunter = new System.Windows.Forms.Button();
            this.buttonRetourner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonModifierOuvrage
            // 
            this.buttonModifierOuvrage.Location = new System.Drawing.Point(197, 58);
            this.buttonModifierOuvrage.Name = "buttonModifierOuvrage";
            this.buttonModifierOuvrage.Size = new System.Drawing.Size(75, 23);
            this.buttonModifierOuvrage.TabIndex = 1;
            this.buttonModifierOuvrage.Text = "Modifier";
            this.buttonModifierOuvrage.UseVisualStyleBackColor = true;
            this.buttonModifierOuvrage.Click += new System.EventHandler(this.buttonModifierOuvrage_Click);
            // 
            // buttonSupprimerOuvrage
            // 
            this.buttonSupprimerOuvrage.Location = new System.Drawing.Point(197, 87);
            this.buttonSupprimerOuvrage.Name = "buttonSupprimerOuvrage";
            this.buttonSupprimerOuvrage.Size = new System.Drawing.Size(75, 23);
            this.buttonSupprimerOuvrage.TabIndex = 2;
            this.buttonSupprimerOuvrage.Text = "Supprimer";
            this.buttonSupprimerOuvrage.UseVisualStyleBackColor = true;
            this.buttonSupprimerOuvrage.Click += new System.EventHandler(this.buttonSupprimerOuvrage_Click);
            // 
            // listBoxOuvrages
            // 
            this.listBoxOuvrages.FormattingEnabled = true;
            this.listBoxOuvrages.Location = new System.Drawing.Point(12, 29);
            this.listBoxOuvrages.Name = "listBoxOuvrages";
            this.listBoxOuvrages.Size = new System.Drawing.Size(168, 82);
            this.listBoxOuvrages.TabIndex = 4;
            this.listBoxOuvrages.SelectedIndexChanged += new System.EventHandler(this.listBoxOuvrages_SelectedIndexChanged);
            // 
            // listBoxPrets
            // 
            this.listBoxPrets.FormattingEnabled = true;
            this.listBoxPrets.Location = new System.Drawing.Point(289, 155);
            this.listBoxPrets.Name = "listBoxPrets";
            this.listBoxPrets.Size = new System.Drawing.Size(258, 82);
            this.listBoxPrets.TabIndex = 5;
            // 
            // labelPrets
            // 
            this.labelPrets.AutoSize = true;
            this.labelPrets.Location = new System.Drawing.Point(286, 138);
            this.labelPrets.Name = "labelPrets";
            this.labelPrets.Size = new System.Drawing.Size(37, 13);
            this.labelPrets.TabIndex = 6;
            this.labelPrets.Text = "Prets :";
            // 
            // labelOuvrages
            // 
            this.labelOuvrages.AutoSize = true;
            this.labelOuvrages.Location = new System.Drawing.Point(9, 12);
            this.labelOuvrages.Name = "labelOuvrages";
            this.labelOuvrages.Size = new System.Drawing.Size(59, 13);
            this.labelOuvrages.TabIndex = 7;
            this.labelOuvrages.Text = "Ouvrages :";
            // 
            // listBoxAdherents
            // 
            this.listBoxAdherents.FormattingEnabled = true;
            this.listBoxAdherents.Location = new System.Drawing.Point(289, 29);
            this.listBoxAdherents.Name = "listBoxAdherents";
            this.listBoxAdherents.Size = new System.Drawing.Size(168, 82);
            this.listBoxAdherents.TabIndex = 8;
            this.listBoxAdherents.SelectedIndexChanged += new System.EventHandler(this.listBoxAhderents_SelectedIndexChanged);
            // 
            // labelAdherent
            // 
            this.labelAdherent.AutoSize = true;
            this.labelAdherent.Location = new System.Drawing.Point(286, 12);
            this.labelAdherent.Name = "labelAdherent";
            this.labelAdherent.Size = new System.Drawing.Size(61, 13);
            this.labelAdherent.TabIndex = 9;
            this.labelAdherent.Text = "Adhèrents :";
            // 
            // buttonAjouterAdherent
            // 
            this.buttonAjouterAdherent.Location = new System.Drawing.Point(472, 29);
            this.buttonAjouterAdherent.Name = "buttonAjouterAdherent";
            this.buttonAjouterAdherent.Size = new System.Drawing.Size(75, 23);
            this.buttonAjouterAdherent.TabIndex = 10;
            this.buttonAjouterAdherent.Text = "Ajouter";
            this.buttonAjouterAdherent.UseVisualStyleBackColor = true;
            this.buttonAjouterAdherent.Click += new System.EventHandler(this.buttonAjouterAdherent_Click);
            // 
            // buttonModifierAdherent
            // 
            this.buttonModifierAdherent.Location = new System.Drawing.Point(472, 58);
            this.buttonModifierAdherent.Name = "buttonModifierAdherent";
            this.buttonModifierAdherent.Size = new System.Drawing.Size(75, 23);
            this.buttonModifierAdherent.TabIndex = 11;
            this.buttonModifierAdherent.Text = "Modifier";
            this.buttonModifierAdherent.UseVisualStyleBackColor = true;
            this.buttonModifierAdherent.Click += new System.EventHandler(this.buttonModifierAdherent_Click);
            // 
            // buttonSupprimerAdherent
            // 
            this.buttonSupprimerAdherent.Location = new System.Drawing.Point(472, 87);
            this.buttonSupprimerAdherent.Name = "buttonSupprimerAdherent";
            this.buttonSupprimerAdherent.Size = new System.Drawing.Size(75, 23);
            this.buttonSupprimerAdherent.TabIndex = 12;
            this.buttonSupprimerAdherent.Text = "Supprimer";
            this.buttonSupprimerAdherent.UseVisualStyleBackColor = true;
            this.buttonSupprimerAdherent.Click += new System.EventHandler(this.buttonSupprimerAdherent_Click);
            // 
            // buttonAjouterOuvrage
            // 
            this.buttonAjouterOuvrage.Location = new System.Drawing.Point(197, 29);
            this.buttonAjouterOuvrage.Name = "buttonAjouterOuvrage";
            this.buttonAjouterOuvrage.Size = new System.Drawing.Size(75, 23);
            this.buttonAjouterOuvrage.TabIndex = 13;
            this.buttonAjouterOuvrage.Text = "Ajouter";
            this.buttonAjouterOuvrage.UseVisualStyleBackColor = true;
            this.buttonAjouterOuvrage.Click += new System.EventHandler(this.buttonAjouterOuvrage_Click);
            // 
            // listBoxExemplaires
            // 
            this.listBoxExemplaires.FormattingEnabled = true;
            this.listBoxExemplaires.Location = new System.Drawing.Point(12, 155);
            this.listBoxExemplaires.Name = "listBoxExemplaires";
            this.listBoxExemplaires.Size = new System.Drawing.Size(168, 82);
            this.listBoxExemplaires.TabIndex = 14;
            // 
            // labelExemplaires
            // 
            this.labelExemplaires.AutoSize = true;
            this.labelExemplaires.Location = new System.Drawing.Point(12, 138);
            this.labelExemplaires.Name = "labelExemplaires";
            this.labelExemplaires.Size = new System.Drawing.Size(69, 13);
            this.labelExemplaires.TabIndex = 15;
            this.labelExemplaires.Text = "Exemplaires :";
            // 
            // buttonEmprunter
            // 
            this.buttonEmprunter.Location = new System.Drawing.Point(197, 155);
            this.buttonEmprunter.Name = "buttonEmprunter";
            this.buttonEmprunter.Size = new System.Drawing.Size(75, 23);
            this.buttonEmprunter.TabIndex = 16;
            this.buttonEmprunter.Text = "Emprunter";
            this.buttonEmprunter.UseVisualStyleBackColor = true;
            this.buttonEmprunter.Click += new System.EventHandler(this.buttonEmprunter_Click);
            // 
            // buttonRetourner
            // 
            this.buttonRetourner.Location = new System.Drawing.Point(197, 184);
            this.buttonRetourner.Name = "buttonRetourner";
            this.buttonRetourner.Size = new System.Drawing.Size(75, 23);
            this.buttonRetourner.TabIndex = 17;
            this.buttonRetourner.Text = "Retourner";
            this.buttonRetourner.UseVisualStyleBackColor = true;
            this.buttonRetourner.Click += new System.EventHandler(this.buttonRetourner_Click);
            // 
            // Fenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 248);
            this.Controls.Add(this.buttonRetourner);
            this.Controls.Add(this.buttonEmprunter);
            this.Controls.Add(this.labelExemplaires);
            this.Controls.Add(this.listBoxExemplaires);
            this.Controls.Add(this.buttonAjouterOuvrage);
            this.Controls.Add(this.buttonSupprimerAdherent);
            this.Controls.Add(this.buttonModifierAdherent);
            this.Controls.Add(this.buttonAjouterAdherent);
            this.Controls.Add(this.labelAdherent);
            this.Controls.Add(this.listBoxAdherents);
            this.Controls.Add(this.labelOuvrages);
            this.Controls.Add(this.labelPrets);
            this.Controls.Add(this.listBoxPrets);
            this.Controls.Add(this.listBoxOuvrages);
            this.Controls.Add(this.buttonSupprimerOuvrage);
            this.Controls.Add(this.buttonModifierOuvrage);
            this.Name = "Fenetre";
            this.Text = "Bibliothèque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonModifierOuvrage;
        private System.Windows.Forms.Button buttonSupprimerOuvrage;
        private System.Windows.Forms.ListBox listBoxOuvrages;
        private System.Windows.Forms.ListBox listBoxPrets;
        private System.Windows.Forms.Label labelPrets;
        private System.Windows.Forms.Label labelOuvrages;
        private System.Windows.Forms.Label labelAdherent;
        private System.Windows.Forms.Button buttonModifierAdherent;
        private System.Windows.Forms.Button buttonSupprimerAdherent;
        private System.Windows.Forms.Button buttonAjouterAdherent;
        private System.Windows.Forms.ListBox listBoxAdherents;
        private System.Windows.Forms.Button buttonAjouterOuvrage;
        private System.Windows.Forms.ListBox listBoxExemplaires;
        private System.Windows.Forms.Label labelExemplaires;
        private System.Windows.Forms.Button buttonEmprunter;
        private System.Windows.Forms.Button buttonRetourner;
    }
}

