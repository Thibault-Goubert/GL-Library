using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using Domaine;
using Persistance;
using System.Collections.Generic;
using NHibernate;

namespace TestBibliotheque
{
    [TestClass]
    public class TestService
    {
        ISessionFactory sessionFactory;
        IDataAccess dataAccess;

        ServiceAdherents serviceAdherents;
        ServicePrets servicePrets;
        ServiceOuvrages serviceOuvrages;
        ServiceExemplaires serviceExemplaires;

        Adherent adherent;
        Ouvrage ouvrage;
        Exemplaire exemplaire1, exemplaire2;

        [TestInitialize]
        public void SetUp()
        {
            sessionFactory = ORM<Adherent>.CreateSessionFactory(true);
            dataAccess = new DataAccess(sessionFactory);

            servicePrets = new ServicePrets(dataAccess);
            serviceAdherents = new ServiceAdherents(dataAccess);
            serviceOuvrages = new ServiceOuvrages(dataAccess);
            serviceExemplaires = new ServiceExemplaires(dataAccess);

            CreateFixtures();
            PopulateDatabase();
        }

        [TestCleanup]
        public void TearDown()
        {
            dataAccess.Dispose();
            sessionFactory.Dispose();
        }

        void CreateFixtures()
        {
            adherent = new Adherent { Nom = "Mario Rossi" };
            ouvrage = new Ouvrage { Titre = "Il grande Gatsby", Auteur = "F. S. Fitzgerald" };
            exemplaire1 = new Exemplaire { Etat = "Nuovo" };
            ouvrage.Add(exemplaire1);
            exemplaire2 = new Exemplaire { Etat = "Usato" };
            ouvrage.Add(exemplaire2);
        }

        void PopulateDatabase()
        {
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction uow = session.BeginTransaction())
            {
                session.Save(adherent);
                session.Save(ouvrage);
                session.Save(exemplaire1);
                session.Save(exemplaire2);
                uow.Commit();
            }
        }

        #region ServicePrets
        [TestMethod]
        public void EmpruntSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, true);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmpruntEchec()
        {
            servicePrets.TraiterEmprunt(adherent.Id, 3);
        }

        [TestMethod]
        public void RetourSucces()
        {
            servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            servicePrets.TraiterRetour(exemplaire1.Id);
            AssertPret(adherent.Id, exemplaire1.Id, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RetourEchec()
        {
            servicePrets.TraiterRetour(exemplaire1.Id);
        }

        void AssertPret(int id_adherent, int id_exemplaire, bool estEnCours)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(id_adherent);
                Exemplaire ex = session.Get<Exemplaire>(id_exemplaire);
                Assert.AreEqual(ex.Id, ad.Prets[0].Exemplaire.Id);
                if (estEnCours)
                    Assert.AreEqual(ad.Id, ex.Adherent.Id);
                else
                    Assert.IsNull(ex.Adherent);
            }
        }
        #endregion ServicePrets

        #region ServiceAdherents
        [TestMethod]
        public void AjouterAdherentSucces()
        {
            Adherent newAdherent = new Adherent() { Nom = "Test Ajout" };
            serviceAdherents.Ajouter(newAdherent);
            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(newAdherent.Id);
                Assert.IsNotNull(ad);
                Assert.AreEqual(ad.Id, newAdherent.Id);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AjouterAdherentEchec()
        {
            serviceAdherents.Ajouter(null);
        }

        [TestMethod]
        public void ModifierAdherentSucces()
        {
            adherent.Nom = "Test Modifier";
            serviceAdherents.Modifier(adherent.Id);

            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(adherent.Id);
                Assert.IsNotNull(ad);
                Assert.AreEqual(adherent.Id, ad.Id);
                Assert.AreEqual("Test Modifier", ad.Nom);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierAdherentEchec()
        {
            serviceAdherents.Modifier(-1);
        }

        [TestMethod]
        public void SupprimerAdherentSucces()
        {
            serviceAdherents.Supprimer(adherent.Id);

            using (ISession session = sessionFactory.OpenSession())
            {
                Adherent ad = session.Get<Adherent>(adherent.Id);
                Assert.IsNull(ad);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerAdherentAvecPretEnCoursEchec()
        {
            //servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            //AssertPret(adherent.Id, exemplaire1.Id, true);
            EmpruntSucces();
            serviceAdherents.Supprimer(adherent.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerAdherentEchec()
        {
            serviceAdherents.Supprimer(-1);
        }
        #endregion

        #region ServiceOuvrage
        [TestMethod]
        public void AjouterOuvrageSucces()
        {
            Ouvrage newOuvrage = new Ouvrage() { Titre = "Test Ajout", Auteur = "Test Ajout" };
            serviceOuvrages.Ajouter(newOuvrage);
            using (ISession session = sessionFactory.OpenSession())
            {
                Ouvrage ou = session.Get<Ouvrage>(newOuvrage.Id);
                Assert.IsNotNull(ou);
                Assert.AreEqual(ou.Id, newOuvrage.Id);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AjouterOuvrageEchec()
        {
            serviceOuvrages.Ajouter(null);
        }

        [TestMethod]
        public void ModifierOuvrageSucces()
        {
            ouvrage.Titre = "Test Modifier";
            ouvrage.Auteur = "Test Modifier";
            serviceOuvrages.Modifier(ouvrage.Id);

            using (ISession session = sessionFactory.OpenSession())
            {
                Ouvrage ou = session.Get<Ouvrage>(ouvrage.Id);
                Assert.IsNotNull(ou);
                Assert.AreEqual(ouvrage.Id, ou.Id);
                Assert.AreEqual("Test Modifier", ou.Titre);
                Assert.AreEqual("Test Modifier", ou.Auteur);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierOuvrageEchec()
        {
            serviceOuvrages.Modifier(-1);
        }

        [TestMethod]
        public void SupprimerOuvrageSucces()
        {
            int ouId = ouvrage.Id;
            serviceOuvrages.Supprimer(ouId);

            using (ISession session = sessionFactory.OpenSession())
            {
                Ouvrage ou = session.Get<Ouvrage>(ouId);
                Assert.IsNull(ou);

                List<Exemplaire> ouExemplaires = serviceExemplaires.ObtenirListeParOuvrage(ouId);
                Assert.IsTrue(ouExemplaires.Count == 0);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerOuvrageAvecExemplairePretEnCoursEchec()
        {
            //servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            //AssertPret(adherent.Id, exemplaire1.Id, true);
            EmpruntSucces();
            serviceOuvrages.Supprimer(ouvrage.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerOuvrageEchec()
        {
            serviceOuvrages.Supprimer(-1);
        }
        #endregion

        #region ServiceExemplaire
        [TestMethod]
        public void AjouterExemplaireSucces()
        {
            Exemplaire newExemplaire = new Exemplaire() { Etat = "Neuf" };
            ouvrage.Add(newExemplaire);
            serviceExemplaires.Ajouter(newExemplaire);
            using (ISession session = sessionFactory.OpenSession())
            {
                Exemplaire ex = session.Get<Exemplaire>(newExemplaire.Id);
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Id, newExemplaire.Id);

                Ouvrage ou = session.Get<Ouvrage>(newExemplaire.Ouvrage.Id);
                Assert.IsNotNull(ou);
                Assert.IsTrue(ou.Exemplaires.Contains(ex));
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AjouterExemplaireEchec()
        {
            serviceExemplaires.Ajouter(null);
        }

        [TestMethod]
        public void ModifierExemplaireSucces()
        {
            exemplaire1.Etat = "Test Modifier";
            serviceExemplaires.Modifier(exemplaire1.Id);

            using (ISession session = sessionFactory.OpenSession())
            {
                Exemplaire ex = session.Get<Exemplaire>(exemplaire1.Id);
                Assert.IsNotNull(ex);
                Assert.AreEqual(exemplaire1.Id, ex.Id);
                Assert.AreEqual("Test Modifier", ex.Etat);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifierExemplaireEchec()
        {
            serviceExemplaires.Modifier(-1);
        }

        [TestMethod]
        public void SupprimerExemplaireSucces()
        {
            int exCount = ouvrage.Exemplaires.Count;
            serviceExemplaires.Supprimer(exemplaire1.Id);

            using (ISession session = sessionFactory.OpenSession())
            {
                Exemplaire ex = session.Get<Exemplaire>(exemplaire1.Id);
                Assert.IsNull(ex);
                Ouvrage ou = session.Get<Ouvrage>(ouvrage.Id);
                Assert.IsNotNull(ou);
                Assert.IsNotNull(ou.Exemplaires);
                Assert.IsTrue(ou.Exemplaires.Count == (exCount - 1));
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerExemplaireAvecPretEnCoursEchec()
        {
            //servicePrets.TraiterEmprunt(adherent.Id, exemplaire1.Id);
            //AssertPret(adherent.Id, exemplaire1.Id, true);
            EmpruntSucces();
            serviceExemplaires.Supprimer(exemplaire1.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SupprimerExemplaireEchec()
        {
            serviceExemplaires.Supprimer(-1);
        }
        #endregion
    }
}
