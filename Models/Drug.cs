namespace DrugWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Drug")]
    public class Drug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugBrand { get; set; }
        public string DrugClass { get; set; }
        public string DrugForm { get; set; }
        public int DrugDose { get; set; }
        public DateTime? MDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

    

    }
}
