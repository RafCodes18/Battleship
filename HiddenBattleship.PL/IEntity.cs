﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.PL
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string SortField { get;}
    }
}
