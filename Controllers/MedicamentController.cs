using Microsoft.AspNetCore.Mvc;
using WebGsbMedicament.Models.Dao;
using WebGsbMedicament.Models.MesExceptions;
using WebGsbMedicament.Models.Metier;

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

		public IActionResult Modifier(String id)
		{
			Prescrire unePrescription = null;
			try
			{
				unePrescription = ServiceMedicament.GetUnePrescription(id);
				return View(unePrescription);
			}catch(MonException e)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult Modifier(Prescrire unePrescription)
		{
			try
			{
				ServiceMedicament.ModifierPrescription(unePrescription);
				return View();
			}
			catch (MonException e)
			{
				return NotFound() ;
			}
		}

	}
}
