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
    [PropertyName("myformAjouterAdherent")]
    public partial class FenetreAjouterAdherent : Form
    {
        ServiceAdherents _ServiceAdherents;
        public FenetreAjouterAdherent(ServiceAdherents serviceAdherents)
        {
            InitializeComponent();
            _ServiceAdherents = serviceAdherents;
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            try
            {
                Domaine.Adherent ad = new Domaine.Adherent() { Nom = tbx_Nom.Text };
                _ServiceAdherents.Ajouter(ad);
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
