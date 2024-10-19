﻿using InventoryMobile.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.Repositories.Signup
{
    public interface ISignupRepository
    {
        Task<bool> CreateAsyn(SignupRequest request);
    }
}
