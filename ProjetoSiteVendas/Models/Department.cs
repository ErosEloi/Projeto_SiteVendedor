using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSiteVendas.Models
{
    [Table("Department")]
    public class Department
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }

    }
}
