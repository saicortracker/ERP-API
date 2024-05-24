using ERP.Dto;
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
        public async Task<JsonResult> GetLeadDetails()
        {
            var leadDetails = (from l in _crmContext.Leads
                               join e in _crmContext.Employees
                               on l.LeadOwner equals e.Id
                               select new LeadDtocs
                               {
                                   leadOwnerName = e.EmployeeName,
                                   FirstName=l.FirstName,
                                   LastName=l.LastName,
                                   Title=l.Title,
                                   Email=l.Email,
                                   Phonenumber=l.Phonenumber,
                                   leadsourcename=l.LeadSource!=null? _crmContext.LeadSources.Where(y=>y.Id==l.LeadSource).FirstOrDefault().Description:null,
                                   leadstatusname=l.LeadStatus!=null?_crmContext.LeadStatuses.Where(y=>y.Id==l.LeadStatus).FirstOrDefault().Description:null

                               }).ToListAsync() ;
                
            //var lead=    await _crmContext.Leads.ToListAsync();
            return new JsonResult(leadDetails.Result.ToList());
        }

        [HttpGet]
        [Route("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            var employeeDetails = await _crmContext.Employees.Select(x => new { x.EmployeeName , x.Id}).ToListAsync();
            return Ok(employeeDetails);
        }

        [HttpGet]
        [Route("GetCompany")]
        public async Task<IActionResult> GetCompany()
        {
            var companyDetails = await _crmContext.Companies.Select(x => new {x.CompanyName, x.Id}).ToListAsync();
            return Ok(companyDetails);
        }

        [HttpGet]
        [Route("GetLeadStatus")]
        public async Task<IActionResult> GetLeadStatus()
        {
            var leadstatusDetails = await _crmContext.LeadStatuses.ToListAsync();
            return Ok(leadstatusDetails);
        }

        [HttpGet]
        [Route("GetLeadSource")]
        public async Task<IActionResult> GetLeadSource()
        {
            var leadsourceDetails = await _crmContext.LeadSources.ToListAsync();
            return Ok(leadsourceDetails);
        }


        [HttpGet]
        [Route("GetIndustry")]
        public async Task<IActionResult> GetInduatry()
        {
            var industryDetails = await _crmContext.Industries.ToListAsync();
            return Ok(industryDetails);
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
