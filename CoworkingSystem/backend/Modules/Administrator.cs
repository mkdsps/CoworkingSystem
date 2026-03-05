using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    internal sealed class Administrator
    {
        public int Id { get; init; }
        public string KorisnickoIme { get; init; } = "";
        public string LozinkaHash { get; init; } = "";
        public string Email { get; init; } = "";
        public string Ime { get; init; } = "";
        public string Prezime { get; init; } = "";
        public bool Aktivan { get; init; }
    }
}
