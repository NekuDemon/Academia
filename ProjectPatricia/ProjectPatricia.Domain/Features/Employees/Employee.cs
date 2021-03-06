﻿using ProjetoPatricia.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Employees
{
    public class Employee : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Position { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new EmployeeEmptyNameException();
            if (string.IsNullOrEmpty(Branch))
                throw new EmployeeEmptyBranchException();
            if (string.IsNullOrEmpty(Position))
                throw new EmployeeEmptyPositionException();
        }
    }
}
