using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace StoreStock.Application.Services
{
    public class CsvService<Entity> : ICsvService<Entity>
    {
        public byte[] ExportarCsv(List<Entity> exportar)
        {
            using var memory = new MemoryStream();

            using var stWriter = new StreamWriter(memory, Encoding.UTF8);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using var csvWriter = new CsvWriter(stWriter, config);

            csvWriter.WriteRecords(exportar);
            stWriter.Flush();

            return memory.ToArray();
        }
    }
}
