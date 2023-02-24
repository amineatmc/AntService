﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CancelText : IEntity
    {
        public int CancelTextID { get; set; }
        public string Text { get; set; }
        public string UserType { get; set; }
    }
}
