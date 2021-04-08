using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceOuvrages : Service
    {
        public ServiceOuvrages(IDataAccess factory) : base(factory) { }

        public List<Ouvrage> ObtenirListe()
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Ouvrage> liste = depotOuvrages.Query().ToList();
                uow.Commit();
                return liste;
            }
        }
        public void Ajouter(Ouvrage ou)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                if (ou == null) throw new Exception("Ne peut pas ajouter un ouvrage null.");
                depotOuvrages.Create(ou);
                uow.Commit();
            }
        }
        public void Modifier(int idOuvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Ouvrage ou = depotOuvrages.Read(idOuvrage);
                if (ou == null) throw new Exception("Ne peut pas modifier un ouvrage avec null.");
                depotOuvrages.Update(ou);
                uow.Commit();
            }
        }
        public void Supprimer(int idOuvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Ouvrage ou = depotOuvrages.Read(idOuvrage);
                if (ou == null)
                    throw new Exception("Ne peut pas supprimer un ouvrage inexistant.");

                List<Exemplaire> ouExemplaires = ou.Exemplaires.Where(e => !e.EstDisponible()).ToList();
                if (ouExemplaires.Count > 0)
                    throw new Exception("Ne peut pas supprimer un ouvrage ayant un exemplaire en cours de pret.");


                while (ou.Exemplaires.Count > 0)
                {
                    Exemplaire ex = ou.Exemplaires[0];

                    List<Pret> exPrets = depotPrets.Query().Where(p => p.Exemplaire != null && p.Exemplaire.Id == ex.Id).ToList();
                    foreach (Pret pret in exPrets)
                    {
                        pret.Exemplaire = null;
                    }

                    ou.Remove(ex);
                    depotExemplaires.Delete(ex);
                }

                depotOuvrages.Delete(ou);
                uow.Commit();
            }
        }
    }
}
