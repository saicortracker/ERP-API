using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public LeadsController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }
        //Get All Contacts
        [HttpGet]
        [Route("GetLeadDetails")]
        public async Task<IActionResult> GetLeadDetails()
        {
            var leadDetails = await _crmContext.Leads.ToListAsync();
            return Ok(leadDetails);
        }
        // Get Contact By Id 
        [HttpGet]
        [Route("GetLeadDetailsbyid/{id}")]
        public async Task<IActionResult> GetLeadDetails(int? id)
        {
            var leadDetails = await _crmContext.Leads.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(leadDetails);
        }
        // Add Contact
        [HttpPost]
        [Route("AddLeadDetails")]
        public async Task<Lead> AddLeadDetail([FromBody] Lead objLeadDetail)
        {

            _crmContext.Leads.Add(objLeadDetail);
            await _crmContext.SaveChangesAsync();
            return objLeadDetail;

        }
        // Update/Edit Contact
        [HttpPut]
        [Route("UpdateLeadDetails")]

        public async Task<IActionResult> EditLeadDetails([FromBody] Lead leadDetails)
        {
            var x = await _crmContext.Leads.FirstOrDefaultAsync(x => x.Id == leadDetails.Id);
            if (x != null)
            {
                x.LeadOwner = leadDetails.LeadOwner;
                x.FirstName = leadDetails.FirstName;
                x.LastName = leadDetails.LastName;
                x.Email = leadDetails.Email;   
                x.Company = leadDetails.Company;
                x.LeadOwner =leadDetails.LeadOwner;
                x.LeadSource = leadDetails.LeadSource;
                x.Mobile = leadDetails.Mobile;
                x.NumberOfEmployees = leadDetails.NumberOfEmployees;
                x.Title = leadDetails.Title;
                x.Phonenumber = leadDetails.Phonenumber;
                x.EmailOutput = leadDetails.EmailOutput;
                x.Rating = leadDetails.Rating; 
                x.SecondaryEmail = leadDetails.SecondaryEmail;
                x.AnnualRevenue = leadDetails.AnnualRevenue;
                x.SkypeId = leadDetails.SkypeId;
                x.Website = leadDetails.Website;
                x.Twitter = leadDetails.Twitter;
                x.LeadStatus = leadDetails.LeadStatus;
                x.Fax = leadDetails.Fax;
               
                _crmContext.Leads.Update(x);
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Lead is not found");
        }

        //Delete Contact
        [HttpDelete]
        [Route("DeleteLeadDetails/{id}")]

        public async Task<IActionResult> DeleteLeadDetails(int id)
        {
            var existingLeadDetails = await _crmContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLeadDetails != null)
            {
                _crmContext.Remove(existingLeadDetails);
                await _crmContext.SaveChangesAsync();
                return Ok(existingLeadDetails);
            }
            return NotFound("Lead is not found");
        }

    }
}
