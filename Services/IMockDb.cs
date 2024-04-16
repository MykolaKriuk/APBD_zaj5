using APBD_zaj5.Classes;

namespace APBD_zaj5.Services;

public interface IMockDb
{
    ICollection<Pet> GetAll();
    Pet? Get(int id);
    bool Add(Pet pet);
    bool Edit(int id, Pet petEdit);
    bool Delete(int id);

    List<Visit> GetVisitsByPetId(int id);
    bool AddVisit(Visit visit, int idOfPet);
}