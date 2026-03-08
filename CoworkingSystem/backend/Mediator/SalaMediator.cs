using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;

namespace CoworkingSystem.backend.Mediator
{
    internal class SalaMediator : IUiMediator
    {
        private readonly SalaService _service;

        internal SalaMediator(SalaService service) => _service = service;

        public UiResult<object?> Send(UiAction action, object? payload = null)
        {
            try
            {
                if (action != UiAction.Add) return UiResult<object?>.Fail("Nepoznata akcija.");

                var sala = payload as Resurs
                           ?? throw new ArgumentException("Payload mora biti Resurs (Sala).");

                int newId = _service.AddSala(sala);
                return UiResult<object?>.Ok(newId, "Sala je dodata.");
            }
            catch (Exception ex)
            {
                return UiResult<object?>.Fail(ex.Message);
            }
        }
    }
}