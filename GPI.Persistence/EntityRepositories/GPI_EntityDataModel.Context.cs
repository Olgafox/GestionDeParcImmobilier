﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GPI.Persistence.EntityRepositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GPI_EntityDataModel : DbContext
    {
        public GPI_EntityDataModel()
            : base("name=GPI_EntityDataModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Demande> Demandes { get; set; }
        public virtual DbSet<Offre> Offres { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TypeImmobilier> TypeImmobiliers { get; set; }
        public virtual DbSet<Vente> Ventes { get; set; }
    }
}