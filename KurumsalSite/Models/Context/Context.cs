using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KurumsalSite.Models.Context
{
    public class Context:DbContext
    {
        public Context():base("KurumsalDB")
        {

        }
        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}