using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Ouvrage
    {
        //Variables
        public virtual int Id { get; set; }
        public virtual string Auteur { get; set; }
        public virtual string Titre { get; set; }
        public virtual IList<Exemplaire> Exemplaires { get; set; }

        //Contructeurs
        public Ouvrage()
        {
            this.Auteur = string.Empty;
            this.Titre = string.Empty;
            this.Exemplaires = new List<Exemplaire>();
        }

        //Méthodes
        public virtual void Add(Exemplaire exemplaire)
        {
            exemplaire.Ouvrage = this;
            this.Exemplaires.Add(exemplaire);
        }
        public virtual void Remove(Exemplaire exemplaire)
        {
            exemplaire.Ouvrage = null;
            this.Exemplaires.Remove(exemplaire);
        }
        public override string ToString()
        {
            return $"({Id}) {Auteur} {Titre} ({Exemplaires.Count})";
        }
    }
}
