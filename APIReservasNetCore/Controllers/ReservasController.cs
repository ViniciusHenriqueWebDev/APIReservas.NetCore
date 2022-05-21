using APIReservasNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIReservasNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private IRepository repository;

        public ReservasController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Reserva> Get() => repository.Reservas;

        [HttpGet("{id}")]
        public Reserva Get(int id) => repository[id];

        [HttpPost]
        public Reserva Post([FromBody] Reserva res) =>
        repository.AddReserva(new Reserva
        {
            Nome = res.Nome,
            InicioLocacao = res.InicioLocacao,
            FImLocacao = res.FImLocacao
        });

        [HttpPut]
        public Reserva Put([FromForm] Reserva res) => repository.UpdateReserva(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm] JsonPatchDocument<Reserva> patch)
        {
            Reserva res = Get(id);
            if(res != null)
            {
                patch.ApplyTo(res);
            }
            return NotFound();
        }
    }
}
