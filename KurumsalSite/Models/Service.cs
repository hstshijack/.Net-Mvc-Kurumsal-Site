using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int Id{ get; set; }
        [Required,StringLength(150,ErrorMessage ="150 Karakter Olmalıdır.")]
        [DisplayName("Hizmet Başlık")]
        public string Ttle{ get; set; }
        [DisplayName("Hizmet Açıklama")]
        public string Description { get; set; }
        [DisplayName("Hizmet Resim")]
        public string PictureUrl { get; set; }

    }
}