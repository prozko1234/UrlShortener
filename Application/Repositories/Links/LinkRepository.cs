using Domain.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Links
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DataContext _context;

        public LinkRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Link link)
        {
            _context.Add(link);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var link = _context.Links.FirstOrDefault(x => x.Id == id);    
            _context.Remove(link);
            _context.SaveChanges();
        }

        public Link GetById(int id)
        {
            var link = _context.Links.FirstOrDefault(x => x.Id == id);
            return link;
        }

        public Link GetByCode(string code)
        {
            var link = _context.Links.FirstOrDefault(x => x.Code == code);
            return link;
        }
        public IEnumerable<Link> GetAll()
        {
            return _context.Links;
        }
    }
}
