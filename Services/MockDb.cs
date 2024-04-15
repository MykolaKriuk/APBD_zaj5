using APBD_zaj5.Classes;

namespace APBD_zaj5.Services;

public class MockDb : IMockDb
{
    private ICollection<Pet> _pets;

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

    public bool Edit(Pet petEdit)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == petEdit.Id);
        if (pet == null) return false;

        pet.Name = petEdit.Name;
        pet.Mass = petEdit.Mass;
        return true;
    }

    public bool Delete(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null) return false;
        
        _pets.Remove(pet);
        return true;
    }
}