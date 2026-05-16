using DAL.EF;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validations
{
    public class PhoneUnique : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = (AgroGuideMsContext)validationContext.GetService(typeof(AgroGuideMsContext));

            var res = (from f in db.Farmers
                       where f.Phone.Equals(value)
                       select f).SingleOrDefault();

            if (res == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Phone number already exists");
        }
    }
}