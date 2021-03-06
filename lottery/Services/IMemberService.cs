﻿using lottery.Models;
using lottery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottery.Services
{
    public interface IMemberService
    {
        IList<MemberViewModel> GetMembers();
    }
}
