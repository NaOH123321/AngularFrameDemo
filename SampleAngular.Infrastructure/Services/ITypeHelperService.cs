using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAngular.Infrastructure.Services
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
