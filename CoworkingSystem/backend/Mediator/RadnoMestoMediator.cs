using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;

namespace CoworkingSystem.backend.Mediator
{
    internal class RadnoMestoMediator : IUiMediator
    {
        private readonly RadnoMestoService _service;

        internal RadnoMestoMediator(RadnoMestoService service)
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
                            var rm = payload as Resurs
                                     ?? throw new ArgumentException("Payload mora biti Resurs (RadnoMesto).");

                            int newId = _service.AddRadnoMesto(rm);
                            return UiResult<object?>.Ok(newId, "Radno mesto je dodato.");
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