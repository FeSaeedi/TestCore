using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dapper
{
    public abstract class DapperRepository
    {
        public abstract Exception ConvertException(Exception exp);

        public Exception TryConvertException(Exception exp)
        {
            Exception res = null;
            try
            {
                res = ConvertException(exp);
            }
            catch (Exception e)
            {

            }
            return res;
        }

    }
}
