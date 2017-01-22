using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class Messager : IMessager
    {
        protected readonly IMessageRepository MessageRepository;
        protected readonly IMapper Mapper;

        public Messager(IMessageRepository messageRepository, IMapper mapper)
        {
            MessageRepository = messageRepository;
            Mapper = mapper;
        }

        public void Send(Guid eventTo, User @from, string message)
        {
            var messageModel = new Storage.POCO.Message
            {
                EventId = eventTo,
                Text = message,
                Time = DateTime.Now,
                UserAccountId = @from.Id
            };
            MessageRepository.Insert(messageModel);
        }

        public IEnumerable<Message> GetAll(Guid eventTo)
        {
            return MessageRepository.GetAll(eventTo)
                .Select(item => Mapper.Map<Storage.POCO.Message, Message>(item));
        }

        public IEnumerable<Message> GetAll(Guid eventTo, User @from)
        {
            throw new NotImplementedException();
        }
    }
}