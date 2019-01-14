using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Infrastructure.Resources.Hateoas
{
    public class LinkCollectionResourceWrapper<T> : LinkResourceBase
        where T : LinkResourceBase
    {
        public LinkCollectionResourceWrapper(IEnumerable<T> value)
        {
            Value = value;
        }

        public IEnumerable<T> Value { get; set; }
    }
}
