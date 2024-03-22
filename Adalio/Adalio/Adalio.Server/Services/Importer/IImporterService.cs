namespace Adalio.Services.Importer
{
    using Domain.Models;
    public interface IImporterService
    {
        public Task<Importer?> GetSingleImporter(Guid guid);
        public Task<List<Importer>?> GetAllImporters();

        public Task<bool> AddImporter(Importer addImporter);
        public Task<bool> DeleteImporter(Guid guid);
        public Task<bool> UpdateImporter(Importer updateImporter);
    }
}