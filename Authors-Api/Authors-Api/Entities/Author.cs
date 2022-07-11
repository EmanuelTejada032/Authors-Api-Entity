using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authors_Api.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(maximumLength: 6, ErrorMessage = "The field {0} can't be more than {1} characters")]
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
        public List<Book> Books { get; set; }
    }
}
