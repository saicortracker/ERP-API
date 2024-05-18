
using CrmModule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CrmModule.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CompaniesController : Controller
    {
        
        private Company company;
        private CrmContext CrmContextDbContext;
        private object GetCompany;
        private object? existingCompany;
    

        public CompaniesController(CrmContext _crmContextDbcontext)
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

                    
        // Get Company By Id 
        [HttpGet]
        [Route("GetCompaniesbyid")]
        public async Task<IActionResult> GetAllCompanies(int? Id)
        {
            var companies = await CrmContextDbContext.Companies.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            
            return Ok(companies);
        }





        // Add Company
        [HttpPost]
        [Route("AddCompany")]
        public async Task<Company> AddCompany([FromBody] Company objCompany)
        {
            CrmContextDbContext.Companies.Add(objCompany);
            await CrmContextDbContext.SaveChangesAsync();
            return objCompany;
        }


        // Update/Edit Company
        [HttpPut]
        [Route("UpdateCompanies")]

        public async Task<IActionResult> EditCompany( [FromBody] Company company)
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

        public async Task<IActionResult> DeleteCompanies( int id)
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
