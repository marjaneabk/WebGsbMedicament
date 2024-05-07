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
				return RedirectToAction("Index");
			}
			catch (MonException e)
			{
                ModelState.AddModelError("Erreur", "Erreur lors de la modif de la prescription : " + e.Message);
                return View("Index") ;
			}
		}

        public IActionResult Ajouter()
        {
            var unePrescription = new Prescrire();

            return View(unePrescription);
        }

        [HttpPost]
		public IActionResult Ajouter(Prescrire unePrescription)
		{
			try
			{
				ServiceMedicament.AddPrescription(unePrescription);
				return RedirectToAction("Index");
			}
			catch (MonException e)
			{
                ModelState.AddModelError("Erreur", "Erreur lors de la modif de la prescription : " + e.Message);
                return View(unePrescription);
            }
		}



	}
}
