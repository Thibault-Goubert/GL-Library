using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServicePrets : Service
    {
        public ServicePrets(IDataAccess factory) : base(factory) { }

        public List<Pret> ObtenirListeParAdherent(int id_adherent)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                List<Pret> liste = depotPrets.Query().Where(p => p.Adherent != null && p.Adherent.Id == id_adherent).ToList();
                uow.Commit();
                return liste;
            }
        }

        public void TraiterEmprunt(int idAdherent, int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Adherent adherent = depotAdherents.Read(idAdherent);
                if (adherent == null) throw new Exception("L'adhérent est inconnu.");
                if (adherent.EstQuotaDepasse()) throw new Exception("L'adhérent ne peut pas emprunter plus d'exemplaires.");

                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);
                if (exemplaire == null) throw new Exception("L'exemplaire est inconnu.");
                if (!exemplaire.EstDisponible()) throw new Exception("L'exemplaire est en cours de prêt.");

                adherent.Emprunte(exemplaire);

                depotAdherents.Update(adherent);
                depotExemplaires.Update(exemplaire);

                uow.Commit();
            }
        }

        public void TraiterRetour(int idExemplaire)
        {
            using (IUnitOfWork uow = BeginTransaction())
            {
                Exemplaire exemplaire = depotExemplaires.Read(idExemplaire);
                if (exemplaire == null) throw new Exception("Cet exemplaire est inconnu.");
                if (exemplaire.EstDisponible()) throw new Exception("Cet exemplaire n'est pas emprunté.");

                Adherent adherent = exemplaire.LouePar();
                adherent.Retourne(exemplaire);

                depotAdherents.Update(adherent);
                depotExemplaires.Update(exemplaire);

                uow.Commit();
            }
        }
    }
}
