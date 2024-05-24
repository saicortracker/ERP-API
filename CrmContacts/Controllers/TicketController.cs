using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public TicketController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }

        //Get All TicketS
        [HttpGet]
        [Route("GetTickets")]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _crmContext.Tickets.ToListAsync();
            return Ok(tickets);
        }

        // Get Ticket By Id 
        [HttpGet]
        [Route("GetTicketsbyid/{id}")]
        public async Task<IActionResult> GetTickets(int? id)
        {
            var tickets = await _crmContext.Tickets.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(tickets);
        }

        //Get Priorities
        [HttpGet]
        [Route("GetPriorities")]
        public async Task<IActionResult> GetPriorities()
        {
            var priorities = await _crmContext.Priorities.ToListAsync();
            return Ok(priorities);
        }

        //Get Pipelines
        [HttpGet]
        [Route("GetPipelines")]
        public async Task<IActionResult> GetPipelines()
        {
            var pipelines = await _crmContext.Pipelines.ToListAsync();
            return Ok(pipelines);
        }

        //Get Ticket Status
        [HttpGet]
        [Route("GetTicketstatuses")]
        public async Task<IActionResult> GetTicketstatus()
        {
            var ticketstatus = await _crmContext.Ticketstatuses.ToListAsync();
            return Ok(ticketstatus);
        }

        //Get Source
        [HttpGet]
        [Route("GetSources")]
        public async Task<IActionResult> GetSources()
        {
            var source = await _crmContext.Sources.ToListAsync();
            return Ok(source);
        }


        // Add Ticket
        [HttpPost]
        [Route("AddTickets")]
        public async Task<Ticket> AddTicket([FromBody] Ticket objTicket)
        {

            _crmContext.Tickets.Add(objTicket);
            await _crmContext.SaveChangesAsync();
            return objTicket;

        }


        // Update/Edit Ticket
        [HttpPut]
        [Route("UpdateTickets")]

        public async Task<IActionResult> EditTickets([FromBody] Ticket Tickets)
        {
            var x = await _crmContext.Tickets.FirstOrDefaultAsync(x => x.Id == Tickets.Id);
            if (x != null)
            {
                x.Ticketname = Tickets.Ticketname;
                x.Pipeline = Tickets.Pipeline;

                x.Ticketstatus = Tickets.Ticketstatus;
                x.Ticketdescription = Tickets.Ticketdescription;
                x.Source = Tickets.Source;
                x.Ticketowner = Tickets.Ticketowner;
                x.Priority = Tickets.Priority;
                x.Createdate = Tickets.Createdate;
                x.Contact = Tickets.Contact;
                x.Company = Tickets.Company;
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Ticket is not found");
        }

        //Delete Ticket
        [HttpDelete]
        [Route("DeleteTickets/{id}")]

        public async Task<IActionResult> DeleteTickets(int id)
        {
            var existingTickets = await _crmContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTickets != null)
            {
                _crmContext.Remove(existingTickets);
                await _crmContext.SaveChangesAsync();
                return Ok(existingTickets);
            }
            return NotFound("Ticket is not found");
        }
    }
}
