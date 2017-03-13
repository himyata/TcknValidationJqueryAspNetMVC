using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TcknValidationJQueryAspNetMVC.Validation
{
    public class TcKimlikNoAttribute : ValidationAttribute, IClientValidatable
    {
        public TcKimlikNoAttribute()
        {

        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule tcKimlikNoRule = new ModelClientValidationRule();
            tcKimlikNoRule.ErrorMessage = errorMessage;
            tcKimlikNoRule.ValidationType = "istckimlikno";

            yield return tcKimlikNoRule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string tcKimlikNo = value == null ? string.Empty : value.ToString();
            bool dogru = false;
            Int64 TcNo = 0;
            if (tcKimlikNo.Length == 11 && Int64.TryParse(tcKimlikNo, out TcNo))
            {
                Int64 ATCNO, BTCNO;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;


                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                dogru = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }

            if (!dogru)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }
    }
}