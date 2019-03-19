﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
 
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
 
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}