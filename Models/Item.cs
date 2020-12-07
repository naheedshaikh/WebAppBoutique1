using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace WebAppBoutique1.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public string categoryId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string Description { get; set; }
        public double itemPrice { get; set; }

        //public httpPostedFileBase ImagePath { get; set; }
    }
}
