using _3._Data.Model;

namespace _3._Data;

public interface ITutorialData
{
    Tutorial GetById(int id);
    List<Tutorial> GetAll();

    bool Create(string name);
}