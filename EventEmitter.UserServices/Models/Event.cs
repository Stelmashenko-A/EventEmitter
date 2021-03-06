﻿using System;

namespace EventEmitter.UserServices.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int Slots { get; set; }

        public int Price { get; set; }

        public bool Blocked { get; set; }

        public User Creator { get; set; }

        public double TimeStamp { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }
    }
}