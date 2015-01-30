using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceInterfaces;

namespace UI
{
    public class ObjectMapper : IObjectMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}
