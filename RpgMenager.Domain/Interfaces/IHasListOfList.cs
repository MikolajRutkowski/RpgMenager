﻿using RpgMenager.Domain.Entities;
using RpgMenager.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMenager.Domain.Interfaces
{
    public interface IHasListOfListStats 
    {
        List<ListOfStatistic> ListOfListStats { get; set; }
    }
}
