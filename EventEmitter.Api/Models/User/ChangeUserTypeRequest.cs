using System;

namespace EventEmitter.Api.Models.User
{
    public class ChangeUserTypeRequest
    {
        public Guid UserId { get; set; }

        public Guid UserTypeId { get; set; }
    }
}