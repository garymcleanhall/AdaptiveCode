using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceInterfaces;

namespace ServiceImplementations
{
    public class MapperAutoMapper : IObjectMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
