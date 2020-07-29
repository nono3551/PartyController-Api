using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyRemote.Data;
using PartyRemote.Data.Models;

namespace PartyRemote.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PartySessionController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PartySessionController(DatabaseContext context)
        {
            this._dbContext = context;
        }

        [HttpGet()]
        public PartySession GetDummyPartySession()
        {
            return new PartySession()
            {
                Title = "Testerino",
                Author = "Janek",
                CurrentSong = "Limbizkit",
                OwnerPassword = "wiiii",
                QueuePassword = "queue",
                SongsCount = 9,
            };
        }

        [HttpPut("{id}/{ownerPassword}")]
        public ActionResult<PartySession> UpdatePartySession(Guid id, string ownerPassword, [FromBody] PartySession partySession)
        {
            var session = _dbContext.PartySessions.FirstOrDefault(session => session.Id == id && partySession.OwnerPassword == ownerPassword);

            if (session == null)
            {
                return NotFound("Object not found");
            }

            session.Title = partySession.Title;

            _dbContext.Update(session);
            _dbContext.SaveChanges();

            session.SetSerializationMode(PartySession.SerializationMode.Owner);

            return session;
        }

        [HttpPost()]
        public PartySession CreatePartySesion([FromBody] PartySession partySession)
        {
            var result = _dbContext.Add(partySession).Entity;

            _dbContext.SaveChanges();

            result.SetSerializationMode(PartySession.SerializationMode.Owner);

            return result;
        }
    }
}
