using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="وارد کردن نام الزامی می باشد")]
        [DisplayName("نام ")]
        public string Name { get; set; }
    }
}
