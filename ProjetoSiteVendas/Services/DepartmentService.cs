using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Models;

namespace ProjetoSiteVendas.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ProjetoSiteVendasContext _context;

        public DepartmentService(ProjetoSiteVendasContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
