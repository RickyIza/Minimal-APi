﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Services
{
    public class ArticuloData : RepositorioBase<Product>, IArticuloData
    {
        private readonly VentasContext ventasContext;
        private readonly ILogger<ArticuloData> logger;


        public ArticuloData(VentasContext ventasContext, ILogger<ArticuloData> logger) : base(ventasContext)
        {
            this.ventasContext = ventasContext;
            this.logger = logger;
        }


    }
}
