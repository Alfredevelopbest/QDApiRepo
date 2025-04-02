using Microsoft.EntityFrameworkCore;
using QD_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace QD_API.Validations
{
    public class ExistCity
    {
        private readonly ApplicationDbContext context;
        public ExistCity(ApplicationDbContext context)
        {
            this.context = context;
        }


        
    }
}
