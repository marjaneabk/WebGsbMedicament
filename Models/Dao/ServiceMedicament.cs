using System.Data;
using WebGsbMedicament.Models.MesExceptions;
using WebGsbMedicament.Models.Persistance;

namespace WebGsbMedicament.Models.Dao
{
	public class ServiceMedicament
	{

		public static DataTable GetTousLesMedicaments()
		{
			DataTable mesMedicaments;
			Serreurs er = new Serreurs("Erreur sur la lecture des medicaments", "Medicament.getMedicament()");
			try
			{
				string mysql = "Select id_medicament, medicament.id_famille, nom_commercial, effets, contre_indication, prix_echantillon, qte_dosage, unite_dosage, posologie, lib_type_individu "
					+ " from medicament join famille on medicament.id_famille = famille.id_famille join prescrire on prescrire.id_medicament = famille.id_famille join dosage on prescrire.id_dosage = dosage.id_dosage join type_individu on prescrire.id_type_individu=type.individu.id_type_individu  ";

				mesMedicaments = DBInterface.Lecture(mysql, er);

			}
			catch (MonException e)
			{
				throw new MonException(er.MessageUtilisateur(), er.MessageApplication());
			}
		}

	}
}
