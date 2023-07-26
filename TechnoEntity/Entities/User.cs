using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoEntity.Entities
{
    public class User:BaseParent
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        // Kullanıcının sahip olduğu ürünler
        public virtual ICollection<Product> Products { get; set; }
    }
}
