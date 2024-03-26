namespace Adalio.Services.Importer
{
    using Adalio.Data;
    using Adalio.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ImporterService(DataContext context) : IImporterService
    {
        private readonly DataContext _context = context;
        public async Task<bool> AddImporter(Importer addImporter)
        {
            try
            {
                if (addImporter is null)
                    throw new ArgumentNullException();
                await _context.Importers.AddAsync(addImporter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteImporter(int guid)
        {
            try
            {
                var selImporter = await _context.Importers.FirstOrDefaultAsync(x => x.Id ==  guid);
                if (selImporter is null)
                    throw new ArgumentNullException();
                _context.Importers.Remove(selImporter);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public async Task<List<Importer>?> GetAllImporters()
            => await _context.Importers.ToListAsync();

        public async Task<Importer?> GetSingleImporter(int guid)
        {
            try
            {
                var selImporter = await _context.Importers.FirstOrDefaultAsync(x => x.Id == guid);
                if (selImporter is null)
                    throw new ArgumentNullException();
                return selImporter;
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
                var selImporter = await _context.Importers.FirstOrDefaultAsync(x => x.Id == updateImporter.Id);
                if (selImporter is null)
                    throw new ArgumentNullException();
                selImporter.Adress = updateImporter.Adress;
                selImporter.LastName = updateImporter.LastName;
                selImporter.Name = updateImporter.Name;
                selImporter.Phone = updateImporter.Phone;
                selImporter.Email = updateImporter.Email;
                selImporter.Marks = updateImporter.Marks;
                selImporter.workAccount = updateImporter.workAccount;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
        }
    }
}
