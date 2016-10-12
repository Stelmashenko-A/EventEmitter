﻿using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Messages")]
    public class Message
    {
        [PrimaryKey, Identity]
        public Guid MessageId { get; set; }

        [Column(Name = "Text"), NotNull]
        public string Text { get; set; }

        [Column(Name = "Time"), NotNull]
        public DateTime Time { get; set; }

        [Column(Name = "UserAccountId"), NotNull]
        public Guid UserAccountId { get; set; }

        [Column(Name = "EventId"), NotNull]
        public Guid EventId { get; set; }
    }
}