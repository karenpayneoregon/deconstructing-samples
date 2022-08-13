using System.Collections.Generic;

namespace ForWritingArticle.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contacts>();
            Customers = new HashSet<Customers>();
        }

        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}