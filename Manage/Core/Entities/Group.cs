using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Entities
{
    public class Group :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSize { get; set; }
        public int CurrentSize { get; set; }
    }
}
