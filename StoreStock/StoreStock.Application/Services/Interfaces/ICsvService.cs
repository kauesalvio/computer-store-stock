using System.Collections.Generic;

namespace StoreStock.Application.Services
{
    public interface ICsvService<Entity>
    {
        byte[] ExportarCsv(List<Entity> exportar);
    }
}