using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Adherent
    {
        //Variables
        public virtual int Id { get; set; }
        public virtual string Nom { get; set; }
        public virtual IList<Pret> Prets { get; set; }

        //Constructors
        public Adherent()
        {
            this.Nom = string.Empty;
            this.Prets = new List<Pret>();
        }

        //Méthodes
        public virtual Pret Emprunte(Exemplaire exemplaire)
        {
            if (!exemplaire.EstDisponible()) throw new Exception($"L'exemplaire n'est pas disponible.");

            Pret newPret = new Pret();

            newPret.Concerne(exemplaire);
            this.Add(newPret);

            exemplaire.Loue(this);

            return newPret;
        }

        public virtual void Add(Pret pret)
        {
            pret.Adherent = this;
            this.Prets.Add(pret);
        }
        public virtual void Retourne(Exemplaire exemplaire)
        {
            Pret pretAdherent = this.Prets.FirstOrDefault(p => !p.EstTermine() && p.Exemplaire.Id == exemplaire.Id);
            if (pretAdherent == null) throw new Exception("L'adhérent n'a pas emprunté cet exemplaire.");
            pretAdherent.Termine();            
            exemplaire.Rendre();
        }
        public virtual bool EstQuotaDepasse()
        {
            return NbPretEnCours() > 4;
        }
        public override string ToString()
        {
            return $"({Id}) {Nom} ({NbPretEnCours()})";
        }
        private int NbPretEnCours()
        {
            return this.Prets.Where(p => p.EstTermine() == false).Count();
        }
    }
}
