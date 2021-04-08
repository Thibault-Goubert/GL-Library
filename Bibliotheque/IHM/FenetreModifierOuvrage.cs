using Domaine;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotheque.IHM
{
    [PropertyName("myformModifierOuvrage")]
    public partial class FenetreModifierOuvrage : Form
    {
        ServiceOuvrages _ServiceOuvrages;
        Ouvrage _Ouvrage;

        public FenetreModifierOuvrage(ServiceOuvrages serviceOuvrages, Ouvrage ouvrage)
        {
            InitializeComponent();
            _ServiceOuvrages = serviceOuvrages;
            _Ouvrage = ouvrage;
            tbx_Auteur.Text = ouvrage.Auteur;
            tbx_Titre.Text = ouvrage.Titre;
            AfficherListe();
        }

        private void btn_AjouterExemplaire_Click(object sender, EventArgs e)
        {
            _Ouvrage.Exemplaires.Add(new Exemplaire() { Etat = "Neuf" });
            AfficherListe();
        }
        private void btn_SupprimerExemplaire_Click(object sender, EventArgs e)
        {
            int idx = lbx_ModifierOuvrage_Exemplaires.SelectedIndex;
            try
            {
                _Ouvrage.Exemplaires.RemoveAt(idx);
                AfficherListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suppression échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_ModifierExemplaire_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = lbx_ModifierOuvrage_Exemplaires.SelectedIndex;
                _Ouvrage.Exemplaires[idx].Etat = tbx_ModifierOuvrageExemplaireEtat.Text;
                AfficherListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modification échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AfficherListe()
        {
            List<string> liste = new List<string>();
            foreach (Exemplaire ex in _Ouvrage.Exemplaires)
                liste.Add(ex.ToString());

            lbx_ModifierOuvrage_Exemplaires.DataSource = liste;
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            _Ouvrage.Auteur = tbx_Auteur.Text;
            _Ouvrage.Titre = tbx_Titre.Text;
            try
            {
                _ServiceOuvrages.Modifier(_Ouvrage.Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
