using Domain.Model;
using Domain.Model.Repository;
using Services.Contract;
using System;
using System.Collections.Generic;

namespace Services
{
    public class PersonService: IPersonService
    {

        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository _personRepository)
        {
            personRepository = _personRepository;
        }
        //public PersonService()
        //{
        //}
        public List<Person> GetList()
        {
            //var list =  new List<Person>() ;
            //list.Add(new Person() { Id=1, Name="ali"});
            //return list;
            return personRepository.GetAll();
        }
    }
}
