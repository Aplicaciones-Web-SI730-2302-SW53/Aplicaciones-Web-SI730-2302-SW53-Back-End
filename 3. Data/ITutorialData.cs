using _3._Data.Model;

namespace _3._Data;

public interface ITutorialData
{
    Tutorial GetById(int id);
    Tutorial GetByTitle(string title);
    Task<List<Tutorial>> GetAllAsync();

    bool Create(Tutorial tutorial);
    bool Update(Tutorial tutorial,int id);
    bool Delete(int id);
}