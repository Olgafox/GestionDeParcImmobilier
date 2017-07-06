//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Vente
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int OffreId { get; set; }
        public int AcheteurId { get; set; }
        public System.DateTime DateVente { get; set; }
        public decimal TauxCommissionAgent { get; set; }
        public decimal TauxCommission { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Client Client { get; set; }
        public virtual Offre Offre { get; set; }
    }
}
