namespace WebApplication6.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class PostWholeFormExampleViewModel
    {
        // I've included this to demonstate that the value isn't lost when you do a post back.
        [DisplayName("Put a message here to prove that it gets posted back and isn't lost when you re-build the form")]
        public string Message { get; set; }

        public int? SelectedPersonId { get; set; }

        [DisplayName("Person")]
        public IList<SelectListItem> People { get; set; }

        public int? SelectedFavouritePetId { get; set; }

        [DisplayName("Favourite pet")]
        public IList<SelectListItem> Pets { get; set; }
    }
}