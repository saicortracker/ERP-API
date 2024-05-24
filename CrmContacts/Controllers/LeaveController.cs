using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public LeaveController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }


        //Get All Contacts
        [HttpGet]
        [Route("GetLeavetypeDetails")]
        public async Task<IActionResult> GetLeavetypeDetails()
        {
            var leavetypeDetails = await _crmContext.Leaves.ToListAsync();
            return Ok(leavetypeDetails);
        }


        // Get status details for drodown
        [HttpGet]
        [Route("GetStatus")]
        public async Task<IActionResult> GetAllStatuses()
        {
            var status = await _crmContext.Statuses.ToListAsync();
            return Ok(status);
        }



        // Get All Leave Types dropdown
        [HttpGet]
        [Route("GetLeaveType")]
        public async Task<IActionResult> GetAllLeaveTypes()
        {
            var leavetype = await _crmContext.LeaveTypes.ToListAsync();
            return Ok(leavetype);
        }



        //Get All Employees dropdown
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<JsonResult> GetAllEmployees()
        {
            var employees = await _crmContext.Employees.Select(x => new { x.Id, x.EmployeeName }).ToListAsync();
            return new JsonResult(employees);
        }

        // Get Leave By Id
        [HttpGet]
        [Route("GetLeavebyid")]
        public async Task<IActionResult> GetAllLeaves(int? Id)
        {
            var leaves = await _crmContext.Leaves.Where(x => x.Id == Id).FirstOrDefaultAsync();

            return Ok(leaves);
        }


        // Add Leave
        [HttpPost]
        [Route("AddLeave")]
        public async Task<Leaf> AddLeave([FromBody] Leaf objLeave)
        {
            _crmContext.Leaves.Add(objLeave);
            await _crmContext.SaveChangesAsync();
            return objLeave;
        }


        // Update/Edit Leave
        [HttpPut]
        [Route("UpdateLeaves")]

        public async Task<IActionResult> EditLeave([FromBody] Leaf leave)
        {
            var x = await _crmContext.Leaves.FirstOrDefaultAsync(x => x.Id == leave.Id);
            if (x != null)
            {
                x.EmployeeId = leave.EmployeeId;
                x.LeaveType = leave.LeaveType;
                x.StartDate = leave.StartDate;
                x.EndDate = leave.EndDate;
                x.Duration = leave.Duration;
                x.BalanceLeaves = leave.BalanceLeaves;
                x.GuidFilename = leave.GuidFilename;
                x.FileName = leave.FileName;
                x.Status = leave.Status;
                x.Remarks = leave.Remarks;
                x.ReportingManager = leave.ReportingManager;
                x.CreatedAt = leave.CreatedAt;
                x.CreatedBy = leave.CreatedBy;
                x.ModifiedAt = leave.ModifiedAt;
                x.ModifiedBy = leave.ModifiedBy;

                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Employee is not found");
        }


        //Delete Employees
        [HttpDelete]
        [Route("DeleteLeaves/{id}")]

        public async Task<IActionResult> DeleteLeaves(int id)
        {
            var existingLeave = await _crmContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLeave != null)
            {
                _crmContext.Remove(existingLeave);
                await _crmContext.SaveChangesAsync();
                return Ok(existingLeave);
            }
            return NotFound("Leave is not found");
        }

    }
}
