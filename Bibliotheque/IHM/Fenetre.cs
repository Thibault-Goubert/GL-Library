using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bibliotheque.IHM;
using Domaine;
using Service;

namespace IHM
{
    public partial class Fenetre : Form
    {
        ServiceExemplaires serviceExemplaires;
        ServiceAdherents serviceAdherents;
        ServiceOuvrages serviceOuvrages;
        ServicePrets servicePrets;

        List<Exemplaire> exemplaires;
        List<Adherent> adherents;
        List<Ouvrage> ouvrages;
        List<Pret> prets;

        public FenetreAjouterOuvrage myformAjouterOuvrage = null;
        public FenetreModifierOuvrage myformModifierOuvrage = null;

        public FenetreAjouterAdherent myformAjouterAdherent = null;
        public FenetreModifierAdherent myformModifierAdherent = null;

        public Fenetre(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            InitializeComponent();

            InitialiserServices(adherents, ouvrages, prets, exemplaires);
            ActualiserAdherents();
            ActualiserOuvrages();
            ActualiserPrets();
        }

        void InitialiserServices(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            serviceExemplaires = exemplaires;
            serviceAdherents = adherents;
            serviceOuvrages = ouvrages;
            servicePrets = prets;
        }

        void ActualiserAdherents()
        {
            adherents = serviceAdherents.ObtenirListe();
            AfficherListe(adherents, listBoxAdherents);
            ActualiserPrets();
        }

        void ActualiserOuvrages()
        {
            ouvrages = serviceOuvrages.ObtenirListe();
            AfficherListe(ouvrages, listBoxOuvrages);
            ActualiserExemplaires();
        }

        void ActualiserPrets()
        {
            int idx = listBoxAdherents.SelectedIndex;

            // TODO:
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int idSelectedAdherent = adherents[idx].Id;
            // 2. Recuperer la liste des prets associés à l'adherent
            prets = servicePrets.ObtenirListeParAdherent(idSelectedAdherent);
            // 3. Afficher la liste des prets
            AfficherListe(prets, listBoxPrets);
        }

        void ActualiserExemplaires()
        {
            int idx = listBoxOuvrages.SelectedIndex;

            // TODO:
            // 1. Recuperer l'identifiant de l'ouvrage selectionné
            int idSelectedOuvrage = ouvrages[idx].Id;
            // 2. Recuperer la liste des exemplaires associés à l'ouvrage
            exemplaires = serviceExemplaires.ObtenirListeParOuvrage(idSelectedOuvrage);
            // 3. Afficher la liste des exemplaires
            AfficherListe(exemplaires, listBoxExemplaires);
        }

        private void listBoxOuvrages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserExemplaires();
        }

        private void listBoxAhderents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserPrets();
        }

        void AfficherListe<T>(List<T> items, ListBox box)
        {
            List<string> liste = new List<string>();
            foreach (T a in items)
                liste.Add(a.ToString());
            box.DataSource = liste;
        }

        private void buttonEmprunter_Click(object sender, EventArgs e)
        {
            if (listBoxExemplaires.Items.Count == 0) return;
            // TODO:
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int idxSelectAdherent = listBoxAdherents.SelectedIndex;
            int idSelectedAdherent = adherents[idxSelectAdherent].Id;
            // 2. Recuperer l'identifiant de l'exemplaire selectionné
            int idSelectedExemplaire = exemplaires[listBoxExemplaires.SelectedIndex].Id;

            try
            {
                // 3. Execution de l'emprunt
                servicePrets.TraiterEmprunt(idSelectedAdherent, idSelectedExemplaire);
                // 4. Mis à jour de l'IHM
                ActualiserAdherents();
                ActualiserExemplaires();
                listBoxAdherents.SelectedIndex = idxSelectAdherent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Emprunt échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            if (listBoxExemplaires.Items.Count == 0) return;
            // TODO:
            int idxSelectedAdherent = listBoxAdherents.SelectedIndex;
            // 1. Recuperer l'identifiant de l'exemplaire selectionné
            int idSelectedExemplaire = exemplaires[listBoxExemplaires.SelectedIndex].Id;

            try
            {
                // 2. Execution du retour
                servicePrets.TraiterRetour(idSelectedExemplaire);
                // 3. Mis à jour de l'IHM
                ActualiserAdherents();
                ActualiserExemplaires();
                listBoxAdherents.SelectedIndex = idxSelectedAdherent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retour échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAjouterOuvrage_Click(object sender, EventArgs e)
        {
            if (myformAjouterOuvrage == null)
            {
                myformAjouterOuvrage = new FenetreAjouterOuvrage(serviceOuvrages);
                myformAjouterOuvrage.FormClosed += new FormClosedEventHandler(OnMyFormClosed);
                myformAjouterOuvrage.ShowDialog();
            }
        }
        private void buttonModifierOuvrage_Click(object sender, EventArgs e)
        {
            if (listBoxOuvrages.Items.Count == 0) return;
            Ouvrage ou = ouvrages[listBoxOuvrages.SelectedIndex];

            if (myformModifierOuvrage == null)
            {
                myformModifierOuvrage = new FenetreModifierOuvrage(serviceOuvrages, ou);
                myformModifierOuvrage.FormClosed += new FormClosedEventHandler(OnMyFormClosed);
                myformModifierOuvrage.ShowDialog();
            }
        }
        private void buttonSupprimerOuvrage_Click(object sender, EventArgs e)
        {
            if (listBoxOuvrages.Items.Count == 0) return;
            int idxOuvrage = listBoxOuvrages.SelectedIndex;
            Ouvrage ouvrage = serviceOuvrages.ObtenirListe()[idxOuvrage];

            DialogResult res = MessageBox.Show(ouvrage.ToString(), "Valider suppression?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    serviceOuvrages.Supprimer(ouvrage.Id);
                    ActualiserOuvrages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Suppression échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAjouterAdherent_Click(object sender, EventArgs e)
        {

            if (myformAjouterAdherent == null)
            {
                myformAjouterAdherent = new FenetreAjouterAdherent(serviceAdherents);
                myformAjouterAdherent.FormClosed += new FormClosedEventHandler(OnMyFormClosed);
                myformAjouterAdherent.ShowDialog();
            }
        }

        private void buttonModifierAdherent_Click(object sender, EventArgs e)
        {
            if (listBoxAdherents.Items.Count == 0) return;
            Adherent ad = adherents[listBoxAdherents.SelectedIndex];

            if (myformModifierAdherent == null)
            {
                myformModifierAdherent = new FenetreModifierAdherent(serviceAdherents, ad);
                myformModifierAdherent.FormClosed += new FormClosedEventHandler(OnMyFormClosed);
                myformModifierAdherent.ShowDialog();
            }
        }

        private void buttonSupprimerAdherent_Click(object sender, EventArgs e)
        {
            if (listBoxAdherents.Items.Count == 0) return;
            int idxAdherent = listBoxAdherents.SelectedIndex;
            Adherent adherent = serviceAdherents.ObtenirListe()[idxAdherent];

            DialogResult res = MessageBox.Show(adherent.ToString(), "Valider suppression?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    serviceAdherents.Supprimer(adherent.Id);
                    ActualiserAdherents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Suppression échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnMyFormClosed(object sender, EventArgs e)
        {
            Type formClosedType = sender.GetType();
            Attribute attr = Attribute.GetCustomAttribute(formClosedType, typeof(PropertyName));
            string propertyName = attr.GetPropValue<string>("Value");
            this.SetFieldValue<Form>(propertyName, null);

            ActualiserAdherents();
            ActualiserOuvrages();
        }
    }
}
