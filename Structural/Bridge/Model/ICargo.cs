﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model;

interface ICargo : ITransport
{
    public float MaxWeight { get; set; } 
}