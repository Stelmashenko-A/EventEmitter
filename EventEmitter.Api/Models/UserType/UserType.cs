﻿using System;

namespace EventEmitter.Api.Models.UserType
{
    public class UserType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Users { get; set; }
        public int ClaimsNumber { get; set; }
    }
}