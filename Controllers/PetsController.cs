using APBD_zaj5.Classes;
using APBD_zaj5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_zaj5.Controllers;

[ApiController]
[Route("vetClinic")]
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

    [HttpPut]
    public IActionResult Edit(Pet petEdit)
    {
        return Ok(_mockDb.Edit(petEdit));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_mockDb.Delete(id));
    }
}