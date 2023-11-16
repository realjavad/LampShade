using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Infrastructre;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Slide;
using ShopManagment.Domain.SlideAgg;
using ShopManagment.Infrastructure.EfCore.Context;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class SlideRepository : RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<SlideViewModelApp> GetList()
        {
            return _context.Slides.Select(x=> new SlideViewModelApp()
            {
                Id = x.Id,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsRemove = x.IsRemove
            }).ToList();
        }

        EditSlideApp ISlideRepository.GetBy(long id)
        {
            return _context.Slides.Select(x => new EditSlideApp()
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Heading = x.Heading,
                Text = x.Text,
                BtnText = x.BtnText
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
