using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repositories.Links
{
    public interface ILinkRepository
    {
        void Add(Link link);
        Link GetById(int id);
        void Delete(int id);
        IEnumerable<Link> GetAll();
        Link GetByCode(string code);
    }
}
