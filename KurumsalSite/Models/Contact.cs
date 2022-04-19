using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250,ErrorMessage ="250 Karakter Olmalıdır.")]
        [DisplayName("Adres")]
        public string Address { get; set; }
        [DisplayName("Telefon")]
        public string Phone { get; set; }      
        public string Fax { get; set; }       
        public string Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}