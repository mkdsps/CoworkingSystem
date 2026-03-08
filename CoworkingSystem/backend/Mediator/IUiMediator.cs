using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Mediator
{
    public interface IUiMediator
    {
        UiResult<object?> Send(UiAction action, object? payload = null);
    }
}
