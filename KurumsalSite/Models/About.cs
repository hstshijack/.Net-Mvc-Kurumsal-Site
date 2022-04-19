using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models
{
    [Table("About")]
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Hakkımızda Açıklama")]
        public string Description { get; set; }

    }
}