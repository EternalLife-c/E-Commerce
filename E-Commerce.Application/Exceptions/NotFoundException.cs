﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key} was not found)")
        {

        }
    }
}
