namespace Adalio.Services.Importer
{
    using Adalio.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ImporterService() : IImporterService
    {
        public async Task<bool> AddImporter(Importer addImporter)
        {
            try
            {
                if (addImporter is null)
                    throw new ArgumentNullException();
                await dbContext.AddImporterAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteImporter(Guid guid)
        {
            try
            {
                var selImporter = await dbContext.GetImporterByIdAsync(guid);
                if (selImporter is null)
                    throw new ArgumentNullException();
                await dbContext.DeleteImporterAsync(selImporter);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Importer>?> GetAllImporters()
            => await dbContext.GetAllImportersAsync();

        public async Task<Importer?> GetSingleImporter(Guid guid)
        {
            try
            {
                var selImporter = await dbContext.GetImporterByIdAsync(guid);
                if (selImporter is null)
                    throw new ArgumentNullException();
                return Task.FromResult(selImporter);
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateImporter(Importer updateImporter)
        {
            try
            {
                var selImporter = await dbContext.GetImporterByIdAsync(updateImporter.Id);
                if (selImporter is null)
                    throw new ArgumentNullException();
                await dbContext.UpdateImporterAsync(selImporter);
                return true;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
