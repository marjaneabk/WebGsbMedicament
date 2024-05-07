using MySql.Data.MySqlClient;
using System;
using System.Data;
using WebGsbMedicament.Models.MesExceptions;
using WebGsbMedicament.Models.Metier;
using WebGsbMedicament.Models.Persistance;

namespace WebGsbMedicament.Models.Dao
{
	public class ServiceMedicament
	{

		public static DataTable GetTousLesMedicaments()
		{
			DataTable mesMedicaments;
			Serreurs er = new Serreurs("Erreur sur la lecture des medicaments", "ServiceMedicament.GetTousLesMedicaments()");
			try
			{
				string mysql = "SELECT medicament.id_medicament, medicament.id_famille, medicament.depot_legal,medicament.nom_commercial, medicament.effets, medicament.contre_indication, medicament.prix_echantillon, famille.lib_famille, dosage.qte_dosage, dosage.unite_dosage, prescrire.posologie, type_individu.lib_type_individu "
					+ " FROM medicament "
					+ " JOIN famille ON medicament.id_famille = famille.id_famille "
					+ " JOIN prescrire ON medicament.id_medicament = prescrire.id_medicament "
					+ " JOIN dosage ON prescrire.id_dosage = dosage.id_dosage "
					+ " JOIN type_individu ON prescrire.id_type_individu = type_individu.id_type_individu";

				mesMedicaments = DBInterface.Lecture(mysql, er);

			}
			catch (MonException e)
			{
				throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
			} 
			return mesMedicaments;
		}

		public static Prescrire GetUnePrescription(String id)
		{
			DataTable dt;
			Prescrire unePrescription = null;
			Serreurs er = new Serreurs("Erreur sur la lecture d'une prescription.", "ServiceMedicament.GetUnePrescription()");
			try
			{
				String mysql = "SELECT id_medicament, id_dosage, id_type_individu, posologie";
				mysql += " FROM prescrire ";
				mysql += " WHERE id_medicament = " + id;
				dt = DBInterface.Lecture(mysql, er);

				if (dt.IsInitialized && dt.Rows.Count > 0)
				{
					unePrescription = new Prescrire();
					DataRow dataRow = dt.Rows[0];
					unePrescription.Id_medicament = int.Parse(dataRow[0].ToString());
					unePrescription.Id_dosage = int.Parse(dataRow[1].ToString());
					unePrescription.Id_type_individu = int.Parse(dataRow[2].ToString());
					unePrescription.Posologie = dataRow[3].ToString();
					return unePrescription;
				}
				else
					return null;
			}
			catch (MonException e)
			{
				throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
			}
			

		}

		public static void ModifierPrescription(Prescrire unePrescription)
		{
			Serreurs er = new Serreurs("Erreur sur la modification d'une prescription.", "ServiceMedicament.ModifierPrescription()");
			String mysql = "UPDATE prescrire " +
				" SET id_dosage = " + unePrescription.Id_dosage + ", " +
				" id_type_individu = " + unePrescription.Id_type_individu + ", " +
				" posologie = '" + unePrescription.Posologie + "'" + 
				" WHERE id_medicament = " + unePrescription.Id_medicament;
			try
			{
				DBInterface.Execute_Transaction(mysql);
			}
			catch (MonException e) {
				throw e;
			}
		}

        public static void AddPrescription(Prescrire unePrep)
        {
            Serreurs er = new Serreurs("Erreur lors de l'ajout d'une prescription.", "ServiceMedicament.AddPrescription()");
            string mysql = "INSERT INTO prescrire (id_dosage, id_medicament, id_type_individu, posologie) " +
                           "VALUES + (" + unePrep.Id_dosage + "', " +
                           unePrep.Id_medicament + "', " +
                           unePrep.Id_type_individu+ "', " +
                           unePrep.Posologie + "', " +
                           "')";
            try
            {
                DBInterface.Execute_Transaction(mysql);

            }
            catch (MonException e)
            {
                throw e;
            }
        }






    }
}
