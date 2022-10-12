﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Core.Services
{
    public interface ICoreService
    {
            Task<List<Report>> GetFBIReports(string searchText);
    }
}
