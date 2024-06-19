using System;

namespace CDMangager.Model.Entities;

internal class CDNotFoundException : ApplicationException
{
    public CDNotFoundException() : base() { }

    public CDNotFoundException(string message) : base(message) { }

    public CDNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
