using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceInterfaces;
using Mapper=AutoMapper.Mapper;

namespace ServiceImplementations.AutoMapper
{
    public class MapperAutoMapper : IObjectMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
