using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    using WebApplication6.Models;

    // This isn't how I would normally do a controller but I've kept it as simple as possible
    // to show how you can get the dropdowns to populate their values
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PostWholeFormExampleViewModel() { Message = "Hello", People = PeopleDropdownItems(), Pets = PetsDropdownItems(1) };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PostWholeFormExampleViewModel viewModel)
        {
            // Normally you would do some sort of validation to make sure the view
            // model that's been posted back is valid, i.e. the user hasn't dicked around with it too much.

            // The drop down options aren't posted back so reload them here.
            viewModel.Pets = PetsDropdownItems(viewModel.SelectedPersonId);
            viewModel.People = PeopleDropdownItems();

            return View(viewModel);
        }

        private static List<SelectListItem> PeopleDropdownItems()
        {
            // This would do a proper database lookup or something and probably not be in the controller (seperation of concern and all that)
            return new List<SelectListItem>
                       {
                           new SelectListItem() { Text = "Simon", Value = 1.ToString() },
                           new SelectListItem() { Text = "Mike", Value = 2.ToString() },
                           new SelectListItem() { Text = "Emma", Value = 3.ToString() }
                       };
        }

        private static List<SelectListItem> PetsDropdownItems(int? selectedPersonId)
        {
            // This would do a proper database lookup or something and probably not be in the controller (seperation of concern and all that)
            var pets = new List<SelectListItem>();
            if (!selectedPersonId.HasValue) return pets;

            switch (selectedPersonId)
            {
                case 1:
                    pets.Add(new SelectListItem { Text = "Rusty" });
                    pets.Add(new SelectListItem { Text = "Claws McFrenzy" });
                    break;
                case 2:
                    pets.Add(new SelectListItem { Text = "Pepsi" });
                    pets.Add(new SelectListItem { Text = "Esmy" });
                    break;
                case 3:
                    pets.Add(new SelectListItem { Text = "Leloo" });
                    pets.Add(new SelectListItem { Text = "Buddy" });
                    pets.Add(new SelectListItem { Text = "Fifi" });
                    break;
            }

            return pets;
        }
    }
}