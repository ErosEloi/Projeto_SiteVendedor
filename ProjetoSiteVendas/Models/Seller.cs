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

        [Required(ErrorMessage ="{0} required")]
        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage ="Digite um E-mail valido")]
        [Display(Name = "E-mail")]
        [Column("email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de Nascimento")]
        [Column("BirthDay")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Salário Base")]
        [Column("BaseSalary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "Departamento")]
        [Column("Department")]
        public Department Department { get; set; } 
        public int DepartmentId { get; set; }

        [Display(Name = "Vendas")]
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
