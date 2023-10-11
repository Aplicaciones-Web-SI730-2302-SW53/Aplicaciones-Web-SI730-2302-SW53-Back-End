namespace _3._Data;

public interface ITutorialData
{
    string GetById(int id);
    string[] GetAll();

    bool Create(string name);
}