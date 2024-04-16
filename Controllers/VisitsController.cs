using APBD_zaj5.Classes;
using APBD_zaj5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zaj5.Controllers;

[ApiController]
[Route("visits")]
public class VisitsController : ControllerBase
{
    private IMockDb _mockDb;
    
    public VisitsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetVisits(int id)
    {
        if (_mockDb.GetVisitsByPetId(id).Count == 0) return NotFound();
        return Ok(_mockDb.GetVisitsByPetId(id));
    }

    [HttpPost("{id}")]
    public IActionResult AddVisit(Visit visit, int id)
    {
        _mockDb.AddVisit(visit, id);
        return Ok("Visit is added");
    }
    
}