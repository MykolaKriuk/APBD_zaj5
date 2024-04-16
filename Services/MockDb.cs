using APBD_zaj5.Classes;

namespace APBD_zaj5.Services;

public class MockDb : IMockDb
{
    private List<Pet> _pets;
    private List<Visit> _visits;

    public MockDb()
    {
        _pets = new List<Pet>
        {
            new()
            {
                Name = "Garry",
                Category = "Snail",
                Mass = 1,
                Color = "Cyan"
            },
            new()
            {
                Name = "Ginger",
                Category = "Cat",
                Mass = 4,
                Color = "Ginger"
            },
            new()
            {
                Name = "Bobby",
                Category = "Dog",
                Mass = 10,
                Color = "Brown"
            }
        };

        _visits = new List<Visit>()
        {
            new()
            {
                DateOfVisit = DateTime.Now,
                PetForVisit = _pets[0],
                InfoOfVisit = "Analysis",
                Price = 50
            },
            new()
            {
                DateOfVisit = DateTime.Now,
                PetForVisit = _pets[1],
                InfoOfVisit = "Surgery",
                Price = 300
            },
            new()
            {
                DateOfVisit = DateTime.Now,
                PetForVisit = _pets[2],
                InfoOfVisit = "Medical treatment",
                Price = 100
            }
        };

    }
        
        
        
    public ICollection<Pet> GetAll()
    {
        return _pets;
    }

    public Pet? Get(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        return pet;
    }

    public bool Add(Pet pet)
    {
        _pets.Add(pet);
        return true;
    }

    public bool Edit(int id, Pet petEdit)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null) return false;

        pet.Name = petEdit.Name;
        pet.Category = petEdit.Category;
        pet.Mass = petEdit.Mass;
        pet.Color = petEdit.Color;
        return true;
    }

    public bool Delete(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null) return false;
        
        _pets.Remove(pet);
        return true;
    }

    public List<Visit> GetVisitsByPetId(int id)
    {
        var visits = _visits.FindAll(v => v.PetForVisit.Id == id);
        return visits;
    }

    public bool AddVisit(Visit visit, int idOfPet)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == idOfPet);
        if (pet == null) return false;
        visit.PetForVisit = pet;
        _visits.Add(visit);
        return true;
    }
}