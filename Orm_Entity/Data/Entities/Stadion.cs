using System;
using System.Collections.Generic;
using System.Text;

namespace Orm_Entity.Data.Entities
{
    class Stadion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyPrice { get; set; }
        public int Capacity { get; set; }
    }
}
