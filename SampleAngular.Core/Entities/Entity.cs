using System;
using System.Collections.Generic;
using System.Text;
using SampleAngular.Core.Interfaces;

namespace SampleAngular.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
