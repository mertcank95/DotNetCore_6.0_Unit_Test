using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
