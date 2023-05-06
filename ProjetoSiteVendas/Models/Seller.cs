using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Linq;


namespace ProjetoSiteVendas.Models
{

    [Table("Seller")]

    public class Seller
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }

        [Display(Name = "email")]
        [Column("email")]
        public string Email { get; set; }

        [Display(Name = "BirthDate")]
        [Column("BirthDay")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "BaseSalary")]
        [Column("BaseSalary")]
        public double BaseSalary { get; set; }

        [Display(Name = "Department")]
        [Column("Department")]
        public Department Department { get; set; }

        [Display(Name = "Sales")]
        [Column("Sales")]
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }




    }
}
