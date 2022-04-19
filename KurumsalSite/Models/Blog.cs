using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models
{
    [Table("Blog")]
    public class Blog
    {
        public int Id { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        public string Content { get; set; }
        [DisplayName("Resim Yolu")]
        public string PictureURL { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }

    }
}