using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public DealsController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }
        //Get All Contacts
        [HttpGet]
        [Route("GetDeals")]
        public async Task<IActionResult> GetDeals()
        {
            var dealDetails = await _crmContext.Deals.ToListAsync();
            return Ok(dealDetails);
        }

        [HttpGet]
        [Route("GetPipeline")]
        public async Task<IActionResult> GetPipeline()
        {
            var pipelineDetails = await _crmContext.Pipelines.ToListAsync();
            return Ok(pipelineDetails);
        }

        [HttpGet]
        [Route("GetContact")]
        public async Task<IActionResult> GetContact()
        {
            var contactDetails = await _crmContext.Contacts.Select(x => new { x.ContactOwner, x.Id }).ToListAsync();
            return Ok(contactDetails);
        }


        [HttpGet]
        [Route("GetPriority")]
        public async Task<IActionResult> GetPriority()
        {
            var priorityDetails = await _crmContext.Priorities.ToListAsync();
            return Ok(priorityDetails);
        }

        [HttpGet]
        [Route("GetDealtype")]
        public async Task<IActionResult> GetDealtype()
        {
            var dealtypeDetails = await _crmContext.Dealtypes.ToListAsync();
            return Ok(dealtypeDetails);
        }

        [HttpGet]
        [Route("GetDealowner")]
        public async Task<IActionResult> GetDealowner()
        {
            var dealownerDetails = await _crmContext.Dealowners.ToListAsync();
            return Ok(dealownerDetails);
        }

        [HttpGet]
        [Route("GetDealstage")]
        public async Task<IActionResult> GetDealstage()
        {
            var dealstageDetails = await _crmContext.Dealstages.ToListAsync();
            return Ok(dealstageDetails);
        }

        [HttpGet]
        [Route("GetLineitem")]
        public async Task<IActionResult> GetLineitem()
        {
            var lineitemDetails = await _crmContext.Addlineitems.ToListAsync();
            return Ok(lineitemDetails);
        }

        // Get Contact By Id 
        [HttpGet]
        [Route("GetDealDetailsbyid/{id}")]
        public async Task<IActionResult> GetDealDetails(int? id)
        {
            var dealDetails = await _crmContext.Deals.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(dealDetails);
        }


        // Add Contact
        [HttpPost]
        [Route("AddDealDetails")]
        public async Task<Deal> AddDealDetail([FromBody] Deal objDealDetail)
        {

            _crmContext.Deals.Add(objDealDetail);
            await _crmContext.SaveChangesAsync();
            return objDealDetail;

        }

        // Update/Edit Contact
        [HttpPut]
        [Route("UpdateDealDetails")]

        public async Task<IActionResult> EditContactDetails([FromBody] Deal dealDetails)
        {
            var x = await _crmContext.Deals.FirstOrDefaultAsync(x => x.Id == dealDetails.Id);
            if (x != null)
            {
                x.Dealname = dealDetails.Dealname;
                x.Pipeline = dealDetails.Pipeline;
                x.Dealtype = dealDetails.Dealtype;
                x.Closedate = dealDetails.Closedate;
                x.Dealstage = dealDetails.Dealstage;
                x.Dealowner = dealDetails.Dealowner;
                x.Amount = dealDetails.Amount;
                x.Addlineitem = dealDetails.Addlineitem;
                x.Company = dealDetails.Company;
                x.Contact = dealDetails.Contact;
                x.Priority = dealDetails.Priority;
                x.Quantity = dealDetails.Quantity;         
                _crmContext.Deals.Update(x);
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Deal is not found");
        }

        //Delete Contact
        [HttpDelete]
        [Route("DeleteDealDetails/{id}")]

        public async Task<IActionResult> DeleteDealDetails(int id)
        {
            var existingDealDetails = await _crmContext.Deals.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDealDetails != null)
            {
                _crmContext.Remove(existingDealDetails);
                await _crmContext.SaveChangesAsync();
                return Ok(existingDealDetails);
            }
            return NotFound("Deal is not found");
        }
    }
}
