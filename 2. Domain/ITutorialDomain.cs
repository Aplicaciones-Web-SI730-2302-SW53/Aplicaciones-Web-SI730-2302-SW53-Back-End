using _3._Data.Model;

namespace _2._Domain;

public interface ITutorialDomain
{
    bool Create(Tutorial tutorial);
    bool Update(Tutorial tutorial,int id);
    bool Delete(int id);
}