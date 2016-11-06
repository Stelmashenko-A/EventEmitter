﻿using System;

namespace EventEmitter.Storage.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public int Slots { get; set; }
        public int Price { get; set; }
        public double TimeStamp { get; set; }
        public Guid EventTypeId { get; set; }
        public string Author { get; set; }
    }
}
