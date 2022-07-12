using Authors_Api.Valiations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authors_Api.Entities
{
    public class Author: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(maximumLength: 6, ErrorMessage = "The field {0} can't be more than {1} characters")]
        [FirstLetterCapitalized]
        public string Name { get; set; }
        [Range(18,85)]
        [NotMapped]
        public int Age { get; set; }
        [CreditCard]
        [NotMapped]
        public string CreditCardNumber { get; set; }
        [Url]
        [NotMapped]
        public string URL { get; set; }
        [NotMapped]
        public int publishedBooks { get; set; }
        [NotMapped]
        public int soldBooks { get; set; }
        public List<Book> Books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(soldBooks > publishedBooks)
            {
                yield return new ValidationResult("sold books can't be more than published books", new string[] {nameof(soldBooks)});
            }

            if (soldBooks < 0)
            {
                yield return new ValidationResult("This must be a positive qunatity", new string[] { nameof(soldBooks) });
            }

            if (publishedBooks < 0)
            {
                yield return new ValidationResult("This must be a positive qunatity", new string[] { nameof(publishedBooks) });
            }

            if (publishedBooks == 0 && soldBooks > 0)
            {
                yield return new ValidationResult("there is no published books so books cannot have been sold", new string[] { nameof(soldBooks) });
            }
        }
    }
}
