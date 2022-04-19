using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models
{
    [Table("Admin")]
    public class AdminEntity
    {
        [Key]
        public int AdminId { get; set; }
        [Required,StringLength(50,ErrorMessage ="En fazla 50 karakter yazabilirsiniz.")]
        public string Mail { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz.")]
        public string Password { get; set; }         
        public string Permission { get; set; }  


    }
}