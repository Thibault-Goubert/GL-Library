using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Exemplaire
    {
        //Variables
        public virtual int Id { get; set; }
        public virtual string Etat { get; set; }
        public virtual Ouvrage Ouvrage { get; set; }
        public virtual Adherent Adherent { get; set; }

        //Constructeurs
        public Exemplaire()
        {
            this.Etat = string.Empty;
            this.Ouvrage = null;
            this.Adherent = null;
        }

        //Méthodes
        public virtual bool EstDisponible()
        {
            return this.Adherent == null;
        }
        public virtual void Loue(Adherent adherent)
        {
            this.Adherent = adherent;
        }
        public virtual Adherent LouePar()
        {
            return this.Adherent;
        }
        public virtual void Rendre()
        {
            this.Adherent = null;
        }
        public override string ToString()
        {
            string id = Id.ToString();
            string etat = Etat;
            string pret = (Adherent == null) ? "(Dispo)" : string.Format($"({Adherent.Nom})({Adherent.Id})");

            return $"({id}) {etat} {pret}";
        }
    }
}
