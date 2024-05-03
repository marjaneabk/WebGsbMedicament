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
				string mysql = "Select id_medicament, medicament.id_famille, depot_legal, nom_commercial, effets, contre_indication, prix_echantillon "
					+ " from medicament join famille on medicament.id_famille = famille.id_famille";

				mesMedicaments = DBInterface.Lecture(mysql, er);

			}
			catch (MonException e)
			{
				throw new MonException(er.MessageUtilisateur(), er.MessageApplication());
			}
		}

	}
}
