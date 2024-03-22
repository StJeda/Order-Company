﻿using Adalio.Domain.Models;
using Adalio.Services.Importer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adalio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImporterController(IImporterService service) : ControllerBase
    {
        private readonly IImporterService _service = service;
        [HttpGet]
        public async Task<IEnumerable<Importer>?> GetAll() 
            => await _service.GetAllImporters();
        [HttpGet("{Guid}")]
        public async Task<ActionResult<Importer?>> Get(Guid guid)
            => Ok(await _service.GetSingleImporter(guid));
        [HttpPost]
        public async Task<bool> Add(Importer importer) 
            => await _service.AddImporter(importer);
        [HttpPut]
        public async Task<bool> Update(Importer importer)
            => await _service.UpdateImporter(importer);
        [HttpDelete]
        public async Task<bool> Delete(Guid guid)
            => await _service.DeleteImporter(guid);
    }
}