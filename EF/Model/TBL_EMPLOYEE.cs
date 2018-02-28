using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class TBL_EMPLOYEE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EMPLOYEE_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string LAST_NAME { get; set; }

        [Required]
        [Range(0, 999999999)]
        public decimal SALARY { get; set; }

        [Required]
        public bool PERMANENT { get; set; }

        public TBL_DEPARTMENT DEPARTMENT_FK { get; set; }
    }
}
