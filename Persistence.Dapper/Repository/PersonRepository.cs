using Core.Dapper;
using Dapper;
using Domain.Model;
using Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Persistence.Dapper.Repository
{
    public class PersonRepository : DapperRepository, IPersonRepository
    {

        private readonly IProvider _provider;
        #region Constructor
        public PersonRepository(IProvider provider)
        {
            _provider = provider;
        }

        public override Exception ConvertException(Exception exp)
        {
            throw new NotImplementedException();
        }
        #endregion
        public List<Person> GetAll()
        {
            var cnn = _provider.GetConnection();

            var arParams = new DynamicParameters();

            arParams.Add("@Id", 1);

            try
            {
                return cnn.Query<Person>("spGetPerson", arParams, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
