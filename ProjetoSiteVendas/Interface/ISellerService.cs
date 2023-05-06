using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Models;
using ProjetoSiteVendas.Services;

namespace ProjetoSiteVendas.Interface
{
    public interface ISellerService
    {

        
        List<Seller> FindAll();
        void Insert(Seller obj);

    }
}
