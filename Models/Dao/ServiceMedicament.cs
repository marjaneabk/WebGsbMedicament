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

		public static Medicament GetUnMedicament(string id)
		{
			DataTable dt;
			Medicament unMedicament = null;

			Serreurs er = new Serreurs("Erreur sur la lecture d'un medicament.", "ServiceMedicament.GetUnMedicament()");

			try
			{
				String mysql = "Select medicament.id_medicament, medicament.id_famille, medicament.nom_commercial, medicament.effets, medicament.contre_indication, medicament.prix_echantillon, dosage.qte_dosage, dosage.unite_dosage, prescrire.posologie, type_individu.lib_type_individu "
					+ " from medicament join famille on medicament.id_famille = famille.id_famille join prescrire on prescrire.id_medicament = famille.id_famille "
					+ " join dosage on prescrire.id_dosage = dosage.id_dosage join type_individu on prescrire.id_type_individu=type_individu.id_type_individu "
					+ " where medicament.id_medicament = " + id;
				if (dt.IsInitialized && dt.Rows.Count > 0)
				{
					unMedicament= new Medicament();
					DataRow dataRow = dt.Rows[0];
					unMedicament.Id_medicament = int.Parse(dataRow[0].ToString());
					unMedicament.Id_famille = int.Parse(dataRow[0].ToString());
					unMedicament.NomCommercial = dataRow[2].ToString();
					unMedicament.Effets = dataRow[3].ToString();
					unMedicament.ContreIndications = dataRow[4].ToString();
					unMedicament.PrixEchantillon = dataRow[5].ToString();
					unMedicament.Unite_dosage = dataRow[7].ToString();
					unMedicament.Posologie = dataRow[8].ToString();
					unMedicament.LibTypeIndividu = dataRow[9].ToString();
					

				}
			}
		}
		 


	}
}
