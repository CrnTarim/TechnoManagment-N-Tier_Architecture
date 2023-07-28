using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoEntity.Entities
{
    public class Product:BaseParent
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductFirm { get; set; }


      
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
    }
}
