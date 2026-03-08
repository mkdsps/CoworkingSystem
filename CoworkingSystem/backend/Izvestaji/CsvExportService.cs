using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Izvestaji
{
    internal class CsvExportService
    {
        public string Exportuj(
            string folderPutanja,
            DateTime periodOd,
            DateTime periodDo,
            object statistikaRadnihMesta,
            object statistikaSala,
            object statistikaTipovaClanstva)
        {
            Directory.CreateDirectory(folderPutanja);

            string fileName = $"izvestaj_{periodDo:yyyyMMdd_HHmmss}.csv";
            string punaPutanja = Path.Combine(folderPutanja, fileName);

            var sb = new StringBuilder();

            sb.AppendLine("IZVESTAJ");
            sb.AppendLine($"Period od;{periodOd:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine($"Period do;{periodDo:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine();

            DodajSekciju(sb, "RADNA MESTA", statistikaRadnihMesta);
            DodajSekciju(sb, "SALE", statistikaSala);
            DodajSekciju(sb, "TIPOVI CLANSTVA", statistikaTipovaClanstva);

            File.WriteAllText(punaPutanja, sb.ToString(), Encoding.UTF8);

            return punaPutanja;
        }

        private void DodajSekciju(StringBuilder sb, string nazivSekcije, object podaci)
        {
            sb.AppendLine(nazivSekcije);

            if (podaci is System.Collections.IEnumerable kolekcija)
            {
                var lista = kolekcija.Cast<object>().ToList();

                if (lista.Count == 0)
                {
                    sb.AppendLine("Nema podataka");
                    sb.AppendLine();
                    return;
                }

                var properties = lista[0].GetType().GetProperties();

                sb.AppendLine(string.Join(";", properties.Select(p => Escape(p.Name))));

                foreach (var item in lista)
                {
                    var vrednosti = properties
                        .Select(p => Escape(p.GetValue(item)?.ToString() ?? ""));

                    sb.AppendLine(string.Join(";", vrednosti));
                }

                sb.AppendLine();
                return;
            }

            sb.AppendLine("Nepoznat format podataka");
            sb.AppendLine();
        }

        private string Escape(string value)
        {
            if (value.Contains(';') || value.Contains('"') || value.Contains('\n'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }

            return value;
        }
    }
}