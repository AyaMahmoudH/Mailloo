using Mailo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mailoo.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

   
        [Range(1, 5, ErrorMessage = "التقييم يجب أن يكون بين 1 و 5.")]
        public int? Rating { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? clientFile { get; set; }
        public byte[]? dbImage { get; set; }
        [NotMapped]
        public string? imageSrc
        {
            get
            {
                if (dbImage != null)
                {
                    string base64String = Convert.ToBase64String(dbImage, 0, dbImage.Length);
                    return "data:image/jpg;base64," + base64String;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
            }
        }

        public DateTime Date { get; set; } = DateTime.Now; 

        [Required]

        public int UserId { get; set; } 

        [ForeignKey("Product")]
        public int ProductId { get; set; } 
        public Product Product { get; set; } 

    }
}
