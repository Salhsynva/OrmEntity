using System;
using System.Collections.Generic;
using System.Text;

namespace Orm_Entity.Data.Entities
{
    class Reservation
    {
        public int Id { get; set; }
        public int StadionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public Stadion Stadion { get; set; }
    }
}
