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
        private readonly ERPContext _crmContext;
        public CompaniesController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }


        //Get All Companies
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _crmContext.Companies.ToListAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("GetCity")]
        public async Task<IActionResult> GetCity()
        {
            var cityDetails = await _crmContext.Cities.ToListAsync();
            return Ok(cityDetails);
        }

        [HttpGet]
        [Route("GetState")]
        public async Task<IActionResult> GetState()
        {
            var stateDetails = await _crmContext.States.ToListAsync();
            return Ok(stateDetails);
        }

        [HttpGet]
        [Route("GetCountry")]
        public async Task<IActionResult> GetCountry()
        {
            var countryDetails = await _crmContext.Countries.ToListAsync();
            return Ok(countryDetails);
        }

        [HttpGet]
        [Route("GetIndustry")]
        public async Task<IActionResult> GetIndustry()
        {
            var industryDetails = await _crmContext.Industries.ToListAsync();
            return Ok(industryDetails);
        }

        [HttpGet]
        [Route("GetTimezone")]
        public async Task<IActionResult> GetTimezone()
        {
            var timezoneDetails = await _crmContext.Timezones.ToListAsync();
            return Ok(timezoneDetails);
        }

        // Get Company By Id 
        [HttpGet]
        [Route("GetCompaniesbyid")]
        public async Task<IActionResult> GetAllCompanies(int? Id)
        {
            var companies = await _crmContext.Companies.Where(x => x.Id == Id).FirstOrDefaultAsync();

            return Ok(companies);
        }





        // Add Company
        [HttpPost]
        [Route("AddCompany")]
        public async Task<Company> AddCompany([FromBody] Company objCompany)
        {
            try
            {
                _crmContext.Companies.Add(objCompany);
                await _crmContext.SaveChangesAsync();
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
                _crmContext.Companies.AddRange(companies);
                await _crmContext.SaveChangesAsync();

                var res = new Response
                {
                    Message = "Data updated successfully",
                    Status = true,
                    Data = companies
                };
                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new Response
                {
                    Message = "An error occurred while saving the companies.",
                    Status = false,
                    Data = ex
                };
                return Ok(res);
            }
        }


        // Update/Edit Company
        [HttpPut]
        [Route("UpdateCompanies")]

        public async Task<IActionResult> EditCompany([FromBody] Company company)
        {
            var x = await _crmContext.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);
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
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Company is not found");
        }






        //Delete Companies
        [HttpDelete]
        [Route("DeleteCompanies/{id}")]

        public async Task<IActionResult> DeleteCompanies(int id)
        {
            var existingComapny = await _crmContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (existingComapny != null)
            {
                _crmContext.Remove(existingComapny);
                await _crmContext.SaveChangesAsync();
                return Ok(existingComapny);
            }
            return NotFound("Company is not found");
        }

    }

}
