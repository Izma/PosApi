using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProductRepository: BaseRepository
    {
        protected ProductRepository(IConnectionFactory factory) : base(factory)
        {
        }
    }
}
