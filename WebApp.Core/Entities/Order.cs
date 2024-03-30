using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public  class Order
    {
        [Required]
        public Guid OrderID { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrderDescription { get; set; }
        public virtual OrderStatus Status { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
    }
}
