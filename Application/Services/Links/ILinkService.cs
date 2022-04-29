using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Links
{
    public interface ILinkService
    {
        LinkDto GetById(int id);
        void Generate(LinkDto link, string currentUrl);
        void Delete(int id);
        LinkDto GetByCode(string code);
        List<LinkDto> GetAll();
    }
}
