﻿using EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.GetProductById;

public class GetProductByIdResponse
{
    public Product Product { get; set; }
}
