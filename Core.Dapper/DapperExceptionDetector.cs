using System;
using System.Data.SqlClient;

namespace Core.Dapper
{
    public static class DapperExceptionDetector
    {
        public static bool IsDeleteHasRelatedDataException(Exception exp, out string typeName, out string keyname)
        {
            typeName = keyname = "";
            if (exp == null)
                return false;
            var res = false;
            var x = exp;
            do
            {
                if (x.Message.ToLower().Contains("could not delete"))
                {
                    res = true;
                    break;
                }
                x = x.InnerException;

            } while (x != null);
            return res;
        }
        public static bool IsDublicateException(Exception exp, out string typeName, out string keyname)
        {
            typeName = keyname = "";
            if (exp == null)
                return false;
            var res = false;
            var x = exp;
            do
            {
                if (x.Message.ToLower().Contains("duplicate") || x.Message.ToLower().Contains("sequence contains more than one element"))
                {
                    res = true;
                    break;
                }
                x = x.InnerException;

            } while (x != null);
            return res;
        }

        public static bool IsNotFoundException(Exception exp, out string typeName, out string keyname)
        {
            typeName = keyname = "";
            if (exp == null)
                return false;
            var res = false;
            var x = exp;
            do
            {
                if (x.Message.ToLower().Contains("sequence contains no elements") || x.Message.ToLower().Contains("sequence contains no matching element"))
                {
                    res = true;
                    break;
                }
                x = x.InnerException;

            } while (x != null);
            return res;
        }

        public static bool IsStoreProcedureCallingException(Exception exp, out string typeName, out string keyName)
        {
            typeName = keyName = "";
            if (exp == null)
                return false;
            var res = false;
            var x = exp;
            do
            {
                var sqlException = exp as SqlException;
                if (sqlException == null)
                    return false;
                if (sqlException.Number == 201 || sqlException.Number == 2812)
                {
                    res = true;
                    break;
                }
                x = x.InnerException;

            } while (x != null);
            return res;
        }
    }
}
