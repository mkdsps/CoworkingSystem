using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;

namespace CoworkingSystem.backend.Mediator
{
    internal class LokacijaMediator : IUiMediator
    {
        private readonly LokacijaService _service;

        internal LokacijaMediator(LokacijaService service)
        {
            _service = service;
        }

        public UiResult<object?> Send(UiAction action, object? payload = null)
        {
            try
            {
                switch (action)
                {
                    case UiAction.Add:
                        {
                            var lok = payload as Lokacija
                                      ?? throw new ArgumentException("Payload mora biti Lokacija.");

                            int newId = _service.AddLokacija(
                                lok.Naziv,
                                lok.Adresa,
                                lok.Grad,
                                lok.RadnoVreme,
                                lok.MaksimalanBrojKorisnika,
                                lok.Opis,
                                lok.Aktivna
                            );

                            return UiResult<object?>.Ok(newId, "Lokacija je dodata.");
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