using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ScoreListDto: IDto
    {
        public int DriverId { get; set; }
        public int Point { get; set; }
    }
}
