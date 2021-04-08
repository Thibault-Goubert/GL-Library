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
    [PropertyName("myformAjouterOuvrage")]
    public partial class FenetreAjouterOuvrage : Form
    {
        //IList<Exemplaire> _Exemplaires;
        ServiceOuvrages _ServiceOuvrages;
        Ouvrage _Ouvrage;

        public FenetreAjouterOuvrage(ServiceOuvrages serviceOuvrages)
        {
            InitializeComponent();
            //_Exemplaires = new List<Exemplaire>();
            _ServiceOuvrages = serviceOuvrages;
            _Ouvrage = new Ouvrage();
        }

        private void btn_AjouterExemplaire_Click(object sender, EventArgs e)
        {
            _Ouvrage.Add(new Exemplaire() { Etat = "Neuf" });
            AfficherListe();
        }
        private void btn_SupprimerExemplaire_Click(object sender, EventArgs e)
        {
            int idx = lbx_AjouterOuvrage_Exemplaires.SelectedIndex;
            try
            {
                _Ouvrage.Remove(_Ouvrage.Exemplaires[idx]);
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
                int idx = lbx_AjouterOuvrage_Exemplaires.SelectedIndex;
                _Ouvrage.Exemplaires[idx].Etat = tbx_ModifierOuvrageExemplaireEtat.Text;
                AfficherListe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modification échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            _Ouvrage.Titre = tbx_Titre.Text;
            _Ouvrage.Auteur = tbx_Auteur.Text;
            try
            {
                _ServiceOuvrages.Ajouter(_Ouvrage);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void AfficherListe()
        {
            List<string> liste = new List<string>();
            foreach (Exemplaire ex in _Ouvrage.Exemplaires)
                liste.Add(ex.ToString());

            lbx_AjouterOuvrage_Exemplaires.DataSource = liste;
        }
    }
}
