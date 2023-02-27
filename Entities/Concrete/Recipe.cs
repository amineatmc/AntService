using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Recipe:IEntity
    {
        public int RecipeID { get; set; }
        public string Region { get; set; }
        public decimal AçılışÜcreti { get; set; }
        public decimal İndiBindi { get; set; }
        public decimal YuzMetrelikMesafeU { get; set; }
        public decimal BirDakikaBeklemeU { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
