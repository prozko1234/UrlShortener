using Application.Dtos;
using Application.Repositories.Links;
using Domain.Models;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Links
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public LinkDto GetById(int id)
        {
            var link = _linkRepository.GetById(id);
            return ConvertToLinkDto(link);
        }

        public LinkDto GetByCode(string code)
        {
            var link = _linkRepository.GetByCode(code);
            return ConvertToLinkDto(link);
        }

        public void Generate(LinkDto link, string currentUrl)
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
            var token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
            var generated = ConvertToLink(link);
            generated.Code = token;
            generated.GeneratedLink = currentUrl + $"/short/{token}";
            _linkRepository.Add(generated);
        }

        public void Delete(int id)
        {
            var link = _linkRepository.GetById(id);
            if (link != null)
                _linkRepository.Delete(id);
        }

        public List<LinkDto> GetAll()
        {
            List<LinkDto> result = new List<LinkDto>();
            var links = _linkRepository.GetAll();

            foreach (var link in links)
            {
                result.Add(ConvertToLinkDto(link));
            }

            return result;
        }

        private LinkDto ConvertToLinkDto(Link link)
        {
            return new LinkDto { Id = link.Id, Code = link.Code, Url = link.Url, GeneratedLink = link.GeneratedLink };
        }

        private Link ConvertToLink(LinkDto link)
        {
            return new Link { Id = link.Id, Code = link.Code, Url = link.Url, GeneratedLink = link.GeneratedLink };
        }
    }
}
