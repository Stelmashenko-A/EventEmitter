using System;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;
using Event = EventEmitter.UserServices.Models.Event;
using Registration = EventEmitter.Storage.POCO.Registration;
using RegistrationType = EventEmitter.UserServices.Models.RegistrationType;

namespace EventEmitter.UserServices.Services
{
    class Registrator : IRegistrator
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;


        public Registrator(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository;
            _mapper = mapper;
        }

        public bool TryRegister(User user, Guid eventId, RegistrationType registrationType)
        {
            try
            {
                var type = _mapper.Map<RegistrationType, Storage.POCO.Enums.RegistrationType>(registrationType);
                if (_registrationRepository.Contains(user.Id, eventId, type))
                {
                    return false;
                }
                _registrationRepository.Insert(new Registration { EventId = eventId, UserAccountId = user.Id, Type = type });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRegistration(User user, Event selectedEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}