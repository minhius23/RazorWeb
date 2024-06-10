using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor09.Models{
    public class Article{
        [Key]
        public int ID{set;get;}
        [StringLength(255)]
        [Required(ErrorMessage ="Tiêu Đề Không được để trống")]
        [Column(TypeName ="nvarchar")]
        public string Title{set;get;}
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created{set;get;}
        [Required(ErrorMessage =" Không được để trống")]

        [Column(TypeName ="ntext")]
        public string Content{set;get;}
    }
}