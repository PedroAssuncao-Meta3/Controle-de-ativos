using AutoMapper;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<TipoPatrimonio, TipoPatrimonioViewModel>().ReverseMap();
            CreateMap<Patrimonio, PatrimonioViewModel>().ReverseMap();
            CreateMap<Atributo, AtributoViewModel>().ReverseMap();
            CreateMap<AtributoXPatrimonio, AtributoXPatrimonioViewModel>().ReverseMap();
            CreateMap<AtributoXTipoPatrimonio, AtributoXTipoPatrimonioViewModel>().ReverseMap();
            CreateMap<MovimentacaoPatrimonio, MovimentacaoPatrimonioViewModel>().ReverseMap();
            CreateMap<TipoMovimentacao, TipoMovimentoViewModel>().ReverseMap();
        }
    }
}
