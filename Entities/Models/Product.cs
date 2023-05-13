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
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StockQuantity { get; set; }

    }
}
