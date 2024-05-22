using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CrmContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public ContactController(ERPContext crmContext)
        {
           _crmContext = crmContext;

        }

        //Get All Contacts
        [HttpGet]
        [Route("GetContactDetails")]
        public async Task<IActionResult> GetContactDetails()
        {
            var contactDetails = await _crmContext.Contacts.ToListAsync();
            return Ok(contactDetails);
        }
        [HttpGet]
        [Route("GetGender")]
        public async Task<IActionResult> GetGender()
        {
            var contactDetails = await _crmContext.Genders.ToListAsync();
            return Ok(contactDetails);
        }
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var contactDetails = await _crmContext.Companies.Select(x=> new { x.CompanyName,x.Id }).ToListAsync();
            return Ok(contactDetails);
        }

        // Get Contact By Id 
        [HttpGet]
        [Route("GetContactDetailsbyid/{id}")]
        public async Task<IActionResult> GetContactDetails(int? id)
        {
            var contactDetails = await _crmContext.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(contactDetails);
        }


        // Add Contact
        [HttpPost]
        [Route("AddContactDetails")]
        public async Task<Contact> AddContactDetail([FromBody] Contact objContactDetail)
        {
            
            _crmContext.Contacts.Add(objContactDetail);
            await _crmContext.SaveChangesAsync();
            return objContactDetail;

        }

        // Update/Edit Contact
        [HttpPut]
        [Route("UpdateContactDetails")]

        public async Task<IActionResult> EditContactDetails([FromBody] Contact contactDetails)
        {
            var x = await _crmContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactDetails.Id);
            if (x != null)
            {
               x.Email = contactDetails.Email;
                x.FirstName = contactDetails.FirstName;
                x.LastName = contactDetails.LastName;
                x.ContactOwner = contactDetails.ContactOwner;
                x.JobTitle = contactDetails.JobTitle;
                x.PhoneNumber = contactDetails.PhoneNumber;
                x.LifeCycleStage = contactDetails.LifeCycleStage;
                x.LeadStatus = contactDetails.LeadStatus;
                x.City = contactDetails.City;
                x.CompanyName = contactDetails.CompanyName;
                x.CountryRegion = contactDetails.CountryRegion;
                x.Industry = contactDetails.Industry;
                x.MobilePhoneNumber = contactDetails.MobilePhoneNumber;
                x.PoastalCode = contactDetails.PoastalCode;
                x.StateRegion = contactDetails.StateRegion;
                x.StreetAddress = contactDetails.StreetAddress;
                x.TimeZone = contactDetails.TimeZone;   
                x.WhatAppPhoneNumber = contactDetails.WhatAppPhoneNumber;
                _crmContext.Contacts.Update(x);
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Contact is not found");
        }

        //Delete Contact
        [HttpDelete]
        [Route("DeleteContactDetails/{id}")]

        public async Task<IActionResult> DeleteContactDetails(int id)
        {
            var existingContactDetails = await _crmContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingContactDetails != null)
            {
                _crmContext.Remove(existingContactDetails);
                await _crmContext.SaveChangesAsync();
                return Ok(existingContactDetails);
            }
            return NotFound("Contact is not found");
        }

    }


}

