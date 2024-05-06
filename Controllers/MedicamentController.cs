using Microsoft.AspNetCore.Mvc;
using WebGsbMedicament.Models.Dao;
using WebGsbMedicament.Models.MesExceptions;

namespace WebGsbMedicament.Controllers
{
	public class MedicamentController : Controller
	{
		public IActionResult Index()
		{
			System.Data.DataTable mesMedicaments = null;

			try
			{
				mesMedicaments = ServiceMedicament.GetTousLesMedicaments();
			}
			catch (MonException e)
			{
				ModelState.AddModelError("Erreur", "Erreur lors de la recuperation des medicaments : " + e.Message);
			}
			return View(mesMedicaments);
		}
	}
}
