using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EF.Model
{
    [Table("TBL_DEPARTMENT")]
    public class TBL_DEPARTMENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
        
        DbSet<TBL_EMPLOYEE> EMPLOYEES { get; set; }
    }
}