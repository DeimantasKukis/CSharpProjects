using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace distributedWarehouses.Models
{
    public class SKU
    {
        public int SkuId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
