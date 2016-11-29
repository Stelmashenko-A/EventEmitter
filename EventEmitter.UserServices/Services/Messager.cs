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
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public Messager(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
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
            _messageRepository.Insert(messageModel);
        }

        public IEnumerable<Message> GetAll(Guid eventTo)
        {
            return _messageRepository.GetAll(eventTo)
                .Select(item => _mapper.Map<Storage.POCO.Message, Message>(item));
        }

        public IEnumerable<Message> GetAll(Guid eventTo, User @from)
        {
            throw new NotImplementedException();
        }
    }
}