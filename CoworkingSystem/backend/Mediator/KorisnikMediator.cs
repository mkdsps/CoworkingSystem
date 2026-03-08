using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;

namespace CoworkingSystem.backend.Mediator
{
    internal class KorisnikMediator : IUiMediator
    {
        private readonly KorisnikService _service;

        public KorisnikMediator(KorisnikService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public UiResult<object?> Send(UiAction action, object? payload = null)
        {
            try
            {
                switch (action)
                {
                    case UiAction.Add:
                        {
                            var k = payload as Korisnik
                                ?? throw new ArgumentException("Payload mora biti Korisnik.");

                            int newId = _service.AddUser(k);
                            return UiResult<object?>.Ok(newId, "Korisnik je dodat.");
                        }

                    case UiAction.GetAll:
                        {
                            var list = _service.GetAll();
                            return UiResult<object?>.Ok(list);
                        }

                    default:
                        return UiResult<object?>.Fail("Nepoznata akcija.");
                }
            }
            catch (Exception ex)
            {
                return UiResult<object?>.Fail(ex.Message);
            }
        }
    }
}