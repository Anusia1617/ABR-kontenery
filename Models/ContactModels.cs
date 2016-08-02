using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Text;

namespace KonteneryMVC.Models
{
    public class ContactModels
    {
        [Required(ErrorMessage = "Proszę podać swoje imie i nazwisko")]
        [Display(Name = "Imię i Nazwisko: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "proszę podać prawidłowy adres e-mail.")]
        [Display(Name = "Adres e-mail: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać swój telefon")]
        [Display(Name = "Telefon: ")]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Proszę wpisać treść wiadomosci.")]
        [Display(Name = "Treść: ")]
        [MaxLength(200)]
        public string Text { get; set; }

        [Display(Name = "Plik z projektem: ")]
        public IEnumerable<HttpPostedFileBase> files { get; set; }
    }
}