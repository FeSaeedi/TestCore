using LibCore.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Repository
{
    public interface IPersonRepository : IRepository
    {
        List<Person> GetAll();
    }
}
