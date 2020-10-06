using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.models;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Route("Cidades")]
    public class CidadesController : Controller
    {
        private readonly Service.IHostedService service;

        public CidadesController(Service.IHostedService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = service.GetCidades();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{Name}", Name = "GetCidade")]
        public IActionResult Get(string Name)
        {
            var model = service.GetCidade(Name);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        /*
                private Cidade ToDomainModel(CidadeInputModel inputModel)
                {
                    return new Cidade()
                    {
                        id = inputModel.id,
                        Name = inputModel.Name,
                        Temp = inputModel.Temp,
                        Date = inputModel.Date
                    };
                }
        */



        //--------------------------------------------------
        //Mapeamentos : modelos envia/recebe dados via API
        private CidadeOutputModel ToOutputModel(Cidade model)
        {
            return new CidadeOutputModel
            {             
                Name = model.Name,
                Temp = model.Temp,
                Date = model.Date,

            };
        }

        private List<CidadeOutputModel> ToOutputModel(List<Cidade> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }

        private CidadeInputModel ToInputModel(Cidade model)
        {
            return new CidadeInputModel
            {                
                Name = model.Name,
                Temp = model.Temp,
                Date = model.Date
            };
        }
    }
}
