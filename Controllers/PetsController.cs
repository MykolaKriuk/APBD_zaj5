using APBD_zaj5.Classes;
using APBD_zaj5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zaj5.Controllers;

[ApiController]
[Route("pets")]
public class PetsController : ControllerBase
{
    private IMockDb _mockDb;

    public PetsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (_mockDb.Get(id) == null) return NotFound();
        return Ok(_mockDb.Get(id));
    }

    [HttpPost]
    public IActionResult Add(Pet pet)
    {
        if (_mockDb.GetAll().FirstOrDefault(x => x.Id == pet.Id) is not null)
            return Conflict();
        
        _mockDb.Add(pet);
        return Ok("Pet is added");
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, Pet petEdit)
    {
        
        // if (_mockDb.Get(id) == null) return NotFound();
        var check = _mockDb.Edit(id, petEdit);
        return check ? Ok($"Pet {id} is edited.") : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var check = _mockDb.Delete(id);
        return check ? Ok($"Pet {id} is deleted.") : NotFound();
    }
    
    // [HttpGet("{id}")]
    // public IActionResult GetVisits(int id)
    // {
    //     if (_mockDb.GetVisitsByPetId(id).Count == 0) return NotFound();
    //     return Ok(_mockDb.GetVisitsByPetId(id));
    // }
}