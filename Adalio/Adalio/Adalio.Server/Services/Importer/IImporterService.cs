namespace Adalio.Services.Importer
{
    using Domain.Models;
    public interface IImporterService
    {
        public Task<Importer?> GetSingleImporter(int id);
        public Task<List<Importer>?> GetAllImporters();

        public Task<bool> AddImporter(Importer addImporter);
        public Task<bool> DeleteImporter(int id);
        public Task<bool> UpdateImporter(Importer updateImporter);
    }
}