﻿using System.Collections.Generic;

namespace ForWritingArticle.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Customers = new HashSet<Customers>();
        }

        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}