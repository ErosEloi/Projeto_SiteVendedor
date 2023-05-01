using ProjetoSiteVendas.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoSiteVendas.Models
{
    [Table("SalesRecord")]
    public class SalesRecord
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int id { get; set; }

        [Display(Name = "Date")]
        [Column("Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Amount")]
        [Column("Amount")]
        public double Amount { get; set; }

        [Display(Name = "Status")]
        [Column("Status")]
        public SaleStatus Status { get; set; }

        [Display(Name = "Seller")]
        [Column("Seller")]
        public Seller Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            this.id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
