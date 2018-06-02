﻿using ProjetoPatricia.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Rooms
{
    public class Room : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}