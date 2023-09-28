﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.UpdateUser
{
    public sealed record UpdateUserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
