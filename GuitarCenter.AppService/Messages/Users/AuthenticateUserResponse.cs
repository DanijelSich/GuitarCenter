﻿using System;
using System.Collections.Generic;
using GuitarCenter.AppService.Messages.Abstractions;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Messages.Users
{
    public class AuthenticateUserResponse : ResponseBase
    {
        public bool Authenticated { get; set; }
    }
}