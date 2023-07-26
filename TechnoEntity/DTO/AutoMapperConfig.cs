using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoEntity.Entities;

namespace TechnoEntity.DTO
{
    public class AutoMapperConfig
    {
        public static IMapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                
                cfg.CreateMap<User, UserDTO>();
                
                cfg.CreateMap<Product, ProductDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
