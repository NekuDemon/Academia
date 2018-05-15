﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class DataValidadeException: Exception
    {
        public DataValidadeException() : base("A data de validade deve ser maior que a data de fabricação.")
        {
        }
    }
}
