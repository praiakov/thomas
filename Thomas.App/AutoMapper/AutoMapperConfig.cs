using AutoMapper;
using Thomas.App.ViewModels;
using Thomas.Business.Models;

namespace Thomas.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Chamado, ChamadoViewModel>().ReverseMap();
        }
    }
}
