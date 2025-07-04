﻿using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IDisabledService
    {
        Task<Disabled?> GetDisabledByUserIdAsync(string userId);
        Task<Disabled?> GetByUserIdAsync(string userId);
        Task<DisabledDto> GetByIdAsync(int id);
    }
}
