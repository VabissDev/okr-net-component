using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Mappers
{
    public abstract class BaseMapper<TEntity, TModel>
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
