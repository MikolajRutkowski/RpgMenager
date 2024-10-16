﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgMenager.Domain.Entities.Abstract;

namespace RpgMenager.Domain.Entities
{
    public class Player :Entity
    {
        public string RealFirstName { get; set; } = default!;
        public string RealLastName { get; set; } = default!;
        public string? Email { get; set; } = default;
        public string? Phone { get; set; } = default;
        public List<PC> PlayerCharacters { get; set; } = new List<PC>();   

        public string CreateName()
        {
            this.Name = RealFirstName + " " + RealLastName ;
            return this.Name;
        }
        public string CreateName(string nick)
        { 
            this.Name = nick;
            return this.Name;
        }
    }
}
