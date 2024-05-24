using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public LeavesController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }

        //Get All Leaves
        [HttpGet]
        [Route("GetLeaveDetails")]
        public async Task<IActionResult> GetLeaves()
        {
            var leavesDetails = await _crmContext.Leaves.ToListAsync();
            return Ok(leavesDetails);
        }

        // Add Leaves
        [HttpPost]
        [Route("AddLeavesDetails")]
        public async Task<Leaves> AddLeave([FromBody] Leaves objleaves)
        {
            _crmContext.Leaves.Add(objleaves);
            await _crmContext.SaveChangesAsync();
            return objleaves;

        }

        // Update/Edit deals
        [HttpPut]
        [Route("UpdateLeavesDetails")]

        public async Task<IActionResult> EditLeaves([FromBody] Leaves leaves)
        {
            var x = await _crmContext.Leaves.FirstOrDefaultAsync(x => x.Id == leaves.Id);
            if (x != null)
            {
                x.EmployeeId = leaves.Id;
                x.LeaveType = leaves.LeaveType;
                x.StartDate = leaves.StartDate;
                x.EndDate = leaves.EndDate;
                x.Duration = leaves.Duration;
                x.BalanceLeaves = leaves.BalanceLeaves;
                x.GuidFilename = leaves.GuidFilename;
                x.FileName = leaves.FileName;
                x.Status = leaves.Status;
                x.Remarks = leaves.Remarks;
                x.ReportingManager = leaves.ReportingManager;
                x.CreatedAt = leaves.CreatedAt;
                x.CreatedBy = leaves.CreatedBy;
                x.ModifiedAt = leaves.ModifiedAt;
                x.ModifiedBy = leaves.ModifiedBy;



                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Employee not found");
        }

        //Delete Leavess
        [HttpDelete]
        [Route("DeleteLeavesDetails/{id}")]

        public async Task<IActionResult> DeleteLeaves(int id)
        {
            var existingLeaves = await _crmContext.Leaves.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLeaves != null)
            {
                _crmContext.Remove(existingLeaves);
                await _crmContext.SaveChangesAsync();
                return Ok(existingLeaves);
            }
            return NotFound("Leave not found");
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

        //Get All Leaves
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeeDetails = await _crmContext.Employees.Select(x => new { x.Id, x.EmployeeName }).ToListAsync();
            return Ok(employeeDetails);
        }

    }
}
