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
    [PropertyName("myformModifierAdherent")]
    public partial class FenetreModifierAdherent : Form
    {
        ServiceAdherents _ServiceAdherents;
        Adherent _Adherent;

        public FenetreModifierAdherent(ServiceAdherents serviceAdherents, Adherent adherent)
        {
            InitializeComponent();
            _ServiceAdherents = serviceAdherents;
            _Adherent = adherent;
            tbx_Nom.Text = adherent.Nom;
        }

        private void btn_Valider_Click(object sender, EventArgs e)
        {
            _Adherent.Nom = tbx_Nom.Text;
            try
            {
                _ServiceAdherents.Modifier(_Adherent.Id);
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
