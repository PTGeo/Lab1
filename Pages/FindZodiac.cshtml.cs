using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class FindZodiac : PageModel
    {
        [BindProperty]
        [Display (Name = "Enter a year:")]
        public int Number { get; set; }
        public string? Zodiac {get; set;}
        public string? ImgSource {get; set;}
        public bool IsValid{get; set;}
        public bool ShowDefault{get; set;} = true;

        public void OnPost()
        {
            ShowDefault = false;
            Zodiac = Models.Utils.GetZodiac(Number);
            IsValid = Validate(Number);
            if(Zodiac.Length > 0 && IsValid)
            {
                ImgSource = $"/images/{Zodiac.ToLower()}.png";
            }
        }

        public void OnGet()
        {
            ViewData["Zodiac"] = "";
            ImgSource = "";
        }

        private bool Validate(int number)
        {
            return number >= 1900 && number <= DateTime.Now.AddYears(1).Year;
        }
    }
}