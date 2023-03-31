using System;
using System.Collections.Generic;

namespace nailon.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProdName { get; set; } = null!;
        public int Price { get; set; }
    }
}
