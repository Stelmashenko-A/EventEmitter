using System;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;
using Registration = EventEmitter.Storage.POCO.Registration;
using RegistrationType = EventEmitter.UserServices.Models.RegistrationType;

namespace EventEmitter.UserServices.Services
{
    public class Registrator : IRegistrator
    {
        protected readonly IRegistrationRepository RegistrationRepository;
        protected readonly IMapper Mapper;


        public Registrator(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            RegistrationRepository = registrationRepository;
            Mapper = mapper;
        }

        public bool TryRegister(User user, Guid eventId, RegistrationType registrationType)
        {
            try
            {
                var registration = RegistrationRepository.Get(user.Id, eventId);
                if (registration != null)
                {
                    return false;
                }
                var type = Mapper.Map<RegistrationType, Storage.POCO.Enums.RegistrationType>(registrationType);
                if (RegistrationRepository.Contains(user.Id, eventId, type))
                {
                    return false;
                }
                RegistrationRepository.Insert(new Registration { EventId = eventId, UserAccountId = user.Id, Type = type });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TryRemoveRegistration(User user, Guid selectedEvent)
        {
            try
            {
                var registration = RegistrationRepository.Get(user.Id, selectedEvent);
                if (registration == null) return false;
                RegistrationRepository.Delete(registration);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}