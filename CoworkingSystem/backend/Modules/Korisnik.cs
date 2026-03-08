using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{   
    internal class Korisnik
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string? Telefon { get; set; }

        public int TipClanstvaId { get; set; }

        public DateTime DatumPocetka { get; set; }

        public DateTime DatumIsteka { get; set; }

        public string Status { get; set; }


        public string? Napomena { get; set; }

        public DateTime DatumRegistracije { get; set; }
        public Korisnik(int id, string ime, string prezime, string email, string? telefon,
                    int tipClanstvaId, DateTime datumPocetka, DateTime datumIsteka, string status,
                    int? lokacijaId, string? napomena, DateTime datumRegistracije)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Telefon = telefon;
            TipClanstvaId = tipClanstvaId;
            DatumPocetka = datumPocetka;
            DatumIsteka = datumIsteka;
            Status = status;
            Napomena = napomena;
            DatumRegistracije = datumRegistracije;
        }

        public Korisnik() { }

        public override string ToString()
        {
            return $"{Id} | {Ime} {Prezime} | {Email} | {Status}";
        }
    }
}
