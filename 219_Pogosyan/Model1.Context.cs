﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _219_Pogosyan
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TRPOLIBRARYEntities1 : DbContext
    {
        public TRPOLIBRARYEntities1()
            : base("name=TRPOLIBRARYEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area_Of_Expertise> Area_Of_Expertise { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Instances> Instances { get; set; }
        public virtual DbSet<Issuance_of_books> Issuance_of_books { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
