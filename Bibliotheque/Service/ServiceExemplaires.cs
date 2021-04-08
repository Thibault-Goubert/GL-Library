using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceExemplaires : Service
    {
        public ServiceExemplaires(IDataAccess factory) : base(factory) { }

        public List<Exemplaire> ObtenirListeParOuvrage(int id_ouvrage)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Exemplaire> liste = depotExemplaires.Query().Where(ex => ex.Ouvrage != null && ex.Ouvrage.Id == id_ouvrage).ToList();
                uow.Commit();
                return liste;
            }
        }
        public void Ajouter(Exemplaire ex)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                //Exemplaire ex = depotExemplaires.Read(idExemplaire);
                if (ex == null) throw new Exception("Ne peut pas ajouter un exemplaire null.");
                if (ex.Ouvrage == null) throw new Exception("Ne peut pas ajouter d'exemplaire sans ouvrage");
                depotExemplaires.Create(ex);
                uow.Commit();
            }
        }
        public void Modifier(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire ex = depotExemplaires.Read(idExemplaire);
                if (ex == null) throw new Exception("Ne peut pas modifier un exemplaire avec null.");
                if (ex.Ouvrage == null) throw new Exception("Ne peut pas modifier d'exemplaire sans ouvrage");
                depotExemplaires.Update(ex);
                uow.Commit();
            }
        }
        public void Supprimer(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire ex = depotExemplaires.Read(idExemplaire);
                if (ex == null) throw new Exception("Ne peut pas supprimer un exemplaire inexistant.");
                if (ex.Ouvrage == null) throw new Exception("Ne peut pas supprimer d'exemplaire sans ouvrage");
                if (!ex.EstDisponible()) throw new Exception("Ne peut pas supprimer un exemplaire en cours de pret.");

                Ouvrage ouvrage = depotOuvrages.Read(ex.Ouvrage.Id);
                if (ouvrage == null) throw new Exception("Ne peut pas supprimer un exemplaire dont l'ouvrage est inexistant.");
                ouvrage.Remove(ex);

                depotExemplaires.Delete(ex);
                uow.Commit();
            }
        }
    }
}
