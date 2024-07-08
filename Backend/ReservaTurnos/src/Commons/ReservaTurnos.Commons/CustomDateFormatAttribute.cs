using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ReservaTurnos.Commons
{
    public class CustomDateFormatAttribute : ValidationAttribute
    {
        private readonly string _dateFormat;

        public CustomDateFormatAttribute(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var dateString = value.ToString();
                if (DateTime.TryParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"La fecha debe estar en el formato {_dateFormat}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
