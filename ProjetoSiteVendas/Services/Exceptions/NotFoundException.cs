using System;

namespace ProjetoSiteVendas.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {

        public NotFoundException(string message) : base(message) 
        {
            
        }

    }
}
