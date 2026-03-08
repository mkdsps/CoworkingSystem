using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;

internal class TipClanstvaMediator : IUiMediator
{
    private readonly TipClanstvaService _service;

    public TipClanstvaMediator(TipClanstvaService service)
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
                        var tp = payload as TipClanstva
                                 ?? throw new ArgumentException("Payload mora biti TipClanstva.");

                        int newId = _service.AddTipClanstva(tp);
                        return UiResult<object?>.Ok(newId, "Tip članstva je dodat.");
                    }

                case UiAction.GetAll:
                    {
                        var list = _service.GetAll(); // List<TipClanstva>
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