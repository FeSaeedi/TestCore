using Domain.Model;
using LibCore.ServicesInterface;
using System.Collections.Generic;

namespace Services.Contract
{
    public interface IPersonService:IService
    {
        List<Person> GetList();
    }
}
