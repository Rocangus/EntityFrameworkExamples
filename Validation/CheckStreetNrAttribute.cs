using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EntityFrameworkExamples.Validation
{
    public class CheckStreetNrAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string input)
            {
                var lastWord = input.Split().Last();
                return int.TryParse(lastWord, out int n);
            }
            return false;
        }
    }
}
