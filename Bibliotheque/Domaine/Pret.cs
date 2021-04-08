using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Pret
    {
        //Variables
        public virtual int Id { get; set; }
        public virtual DateTime DateEmprunt { get; set; }
        public virtual DateTime DateRetour { get; set; }
        public virtual Adherent Adherent { get; set; }
        public virtual Exemplaire Exemplaire { get; set; }

        //Constructors
        public Pret()
        {
            this.DateEmprunt = DateTime.Now;
            this.DateRetour = DateTime.MinValue;
            this.Adherent = null;
            this.Exemplaire = null;
        }

        //Méthodes
        public virtual bool EstTermine()
        {
            return this.DateRetour >= this.DateEmprunt;
        }
        public virtual void Concerne(Exemplaire exemplaire)
        {
            this.Exemplaire = exemplaire;
        }
        public virtual void Termine()
        {
            this.DateRetour = DateTime.Now;
        }
        public override string ToString()
        {
            string id = Id.ToString();
            string dateEmprunt = string.Format("{0:(dd/MM/yy)}", DateEmprunt);
            string dateRetour = (DateRetour == DateTime.MinValue) ? "" : string.Format("{0:/(dd/MM/yy)}", DateRetour);
            //string adherent = (Adherent == null) ? "(null)" : Adherent.Nom;
            string exemplaire = (Exemplaire == null) ? "(null)" : Exemplaire.Ouvrage == null ? "(null)" : Exemplaire.Ouvrage.Titre;

            return $"({id}) {dateEmprunt}{dateRetour} {exemplaire}";
        }
    }
}
