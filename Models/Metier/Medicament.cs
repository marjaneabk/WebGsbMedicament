namespace WebGsbMedicament.Models.Metier
{
	public class Medicament
	{
		private int id_medicament;
		private int id_famille;
		private String depot_legal;
		private String nom_commercial;
		private String effets;
		private String contre_indication;
		private String prix_echantillon;

		public int Id_medicament { get => id_medicament; set => id_medicament = value; }
		public int Id_famille { get => id_famille; set => id_famille = value; }
		public string DepotLegal { get => depot_legal; set => depot_legal = value; }
		public string NomCommercial { get => nom_commercial; set => nom_commercial = value; }
		public string Effets { get => effets; set => effets = value; }
		public string ContreIndications { get => contre_indication; set => contre_indication = value; }
		public string PrixEchantillon { get => prix_echantillon; set => prix_echantillon = value; }



	}
}
