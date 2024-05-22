using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CrmContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private Company company;
        private ERPContext CrmContextDbContext;
        private object GetCompany;
        private object? existingCompany;


        public CompaniesController(ERPContext _crmContextDbcontext)
        {
            CrmContextDbContext = _crmContextDbcontext;
        }


        //Get All Companies
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await CrmContextDbContext.Companies.ToListAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("GetCity")]
        public async Task<IActionResult> GetCity()
        {
            var cityDetails = await CrmContextDbContext.Cities.ToListAsync();
            return Ok(cityDetails);
        }


        // Get Company By Id 
        [HttpGet]
        [Route("GetCompaniesbyid")]
        public async Task<IActionResult> GetAllCompanies(int? Id)
        {
            var companies = await CrmContextDbContext.Companies.Where(x => x.Id == Id).FirstOrDefaultAsync();

            return Ok(companies);
        }





        // Add Company
        [HttpPost]
        [Route("AddCompany")]
        public async Task<Company> AddCompany([FromBody] Company objCompany)
        {
            try
            {
                CrmContextDbContext.Companies.Add(objCompany);
                await CrmContextDbContext.SaveChangesAsync();
                return objCompany;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Bulkupload")]
        public async Task<IActionResult> Bulkupload([FromBody] List<Company> companies)
        {
            try
            {
                CrmContextDbContext.Companies.AddRange(companies);
                await CrmContextDbContext.SaveChangesAsync();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving the companies.");
            }
        }


        // Update/Edit Company
        [HttpPut]
        [Route("UpdateCompanies")]

        public async Task<IActionResult> EditCompany([FromBody] Company company)
        {
            var x = await CrmContextDbContext.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);
            if (x != null)
            {
                x.CompanyName = company.CompanyName;
                x.CompanyOwner = company.CompanyOwner;
                x.Type = company.Type;
                x.City = company.City;
                x.RegionState = company.RegionState;
                x.PostalCode = company.PostalCode;
                x.NumberOfEmplyees = company.NumberOfEmplyees;
                x.AnnualRevenue = company.AnnualRevenue;
                x.TimeZone = company.TimeZone;
                x.Discription = company.Discription;
                x.LinkedinCompanyPage = company.LinkedinCompanyPage;
                await CrmContextDbContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Company is not found");
        }






        //Delete Companies
        [HttpDelete]
        [Route("DeleteCompanies/{id}")]

        public async Task<IActionResult> DeleteCompanies(int id)
        {
            var existingComapny = await CrmContextDbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (existingComapny != null)
            {
                CrmContextDbContext.Remove(existingComapny);
                await CrmContextDbContext.SaveChangesAsync();
                return Ok(existingComapny);
            }
            return NotFound("Company is not found");
        }

    }

}
