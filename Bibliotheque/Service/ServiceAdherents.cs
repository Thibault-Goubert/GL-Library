using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAdherents : Service
    {
        public ServiceAdherents(IDataAccess factory) : base(factory) { }


        public List<Adherent> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Adherent> liste = depotAdherents.Query().ToList();
                uow.Commit();
                return liste;
            }
        }
        public void Ajouter(Adherent ad)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                //Adherent ad = depotAdherents.Read(idAdherent);
                if (ad == null) throw new Exception("Ne peut pas ajouter un adherent null.");
                depotAdherents.Create(ad);
                uow.Commit();
            }
        }
        public void Modifier(int idAdherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent ad = depotAdherents.Read(idAdherent);
                if (ad == null) throw new Exception("Ne peut pas modifier un adherent avec null.");
                depotAdherents.Update(ad);
                uow.Commit();
            }
        }
        public void Supprimer(int idAdherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent ad = depotAdherents.Read(idAdherent);
                if (ad == null) throw new Exception("Ne peut pas supprimer un adherent inexistant.");

                List<Pret> adPrets = ad.Prets.Where(p => !p.EstTermine()).ToList();
                if (adPrets.Count > 0) throw new Exception("Ne peut pas supprimer un adherent ayant un pret en cours.");

                while (ad.Prets.Count > 0)
                {
                    Pret pret = ad.Prets[0];
                    pret.Adherent = null;
                    pret.Exemplaire = null;
                    ad.Prets.Remove(pret);
                    depotPrets.Delete(pret);
                }

                depotAdherents.Delete(ad);
                uow.Commit();
            }
        }
    }
}
