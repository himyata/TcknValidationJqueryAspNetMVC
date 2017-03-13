using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TcknValidationJQueryAspNetMVC.Validation;

namespace TcknValidationJQueryAspNetMVC.Models
{

    public class Person
    {
        [Required(ErrorMessage = "Ad Gerekli", AllowEmptyStrings = false)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad Gerekli", AllowEmptyStrings = false)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Tc No Gerekli")]
        [TcKimlikNo(ErrorMessage = "Kimlik numarasını doğru bir şekilde giriniz")]
        public long TCKN { get; set; }
    }
}