namespace WebGsbMedicament.Models.Metier
{
	public class Medicament
	{
		private int id_medicament;
		private int id_famille;
		private String depotLegal;
		private String nomCommercial;
		private String effets;
		private String contreIndications;
		private String prixEchantillon;

		public int Id_medicament { get => id_medicament; set => id_medicament = value; }
		public int Id_famille { get => id_famille; set => id_famille = value; }
		public string DepotLegal { get => depotLegal; set => depotLegal = value; }
		public string NomCommercial { get => nomCommercial; set => nomCommercial = value; }
		public string Effets { get => effets; set => effets = value; }
		public string ContreIndications { get => contreIndications; set => contreIndications = value; }
		public string PrixEchantillon { get => prixEchantillon; set => prixEchantillon = value; }



	}
}
