﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record IntegrationAccountDto
    {
        public string CustomerId { get; set; }
        public decimal Balance{get;set;}
    }
}