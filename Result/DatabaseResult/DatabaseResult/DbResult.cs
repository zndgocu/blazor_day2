using System;
using System.Data;

namespace DatabaseResult
{
    public class DbResult
    {
        public DbResult(EN_RESULT_CODE resultCode, int dbResultCode, DataTable dataTable, int count, string message = "")
        {
            ResultCode = resultCode;
            DbResultCode = dbResultCode;
            DataTable = dataTable;
            Count = count;
            DbResultMessage = message;
        }

        public enum EN_DB_TYPE
        {
            PostgreSql = 1,
            Oracle,
            MongoDb,
            MSSql,
            MySql,
        }

        public enum EN_RESULT_CODE
        {
            Negative = -1,
            Positive = 1,
        }

        /// <summary>
        /// 우리가 쓸것
        /// </summary>
        public EN_RESULT_CODE ResultCode { get; set; }

        public bool IsPositive
        {
            get
            {
                return (ResultCode == EN_RESULT_CODE.Positive);
            }
        }

        public bool IsNegative
        {
            get
            {
                return (ResultCode == EN_RESULT_CODE.Negative);
            }
        }

        /// <summary>
        /// 실제 Db에서 리턴주는 것
        /// </summary>
        public int DbResultCode { get; set; }

        /// <summary>
        /// 실제 Db에서 리턴주는 것
        /// </summary>
        public string DbResultMessage { get; set; }

        /// <summary>
        /// excuteQuery return
        /// </summary>
        public DataTable DataTable { get; set; } = new DataTable();

        /// <summary>
        /// excuteQuery, excueNonQuery Return
        /// </summary>
        public int Count { get; set; } = -1;


        public string GetErrorMessage_ResultCode()
        {
            string message = string.Empty;
            switch(ResultCode)
            {
                case EN_RESULT_CODE.Positive:
                    {
                        message = "SUCCESS";
                        break;
                    }
                case EN_RESULT_CODE.Negative:
                    {
                        message = "FAIL";
                        break;
                    }
                default:
                    {
                        message = "알수 없는 코드";
                        break;
                    }
            }
            return message;
        }

        public string GetErrorMessage_DbResultCode()
        {
            string message = string.Empty;
            return $"{DbResultCode}";
        }
    }
}
