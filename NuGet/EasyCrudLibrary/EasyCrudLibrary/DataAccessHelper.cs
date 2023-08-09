﻿using EasyCrudLibrary.Model;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyCrudLibrary
{
    public static class DataAccessHelper
    {
        public static int GetColumnOrder(SqlDataReader reader, string name)
        {
            int columnOrdinal = reader.GetOrdinal(name);
            return columnOrdinal;
        }

        public static T GetValue<T>(this SqlDataReader sqlDataReader, string columnName)
        {
            var value = sqlDataReader[columnName];

            return value == System.DBNull.Value ? default(T) : (T)value;
        }

        public static string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        public static bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetMD5HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ConverOrderListToSQL(string commandText, List<OrderByModel> orderBy)
        {
            if (orderBy != null && orderBy.Count > 0)
            {
                var newCommandText = commandText;
                Regex yourRegex = new Regex(@"(?<=by\s+).*?(?=\s+OFFSET)");
                string orderStr = "";
                foreach (var r in orderBy)
                {
                    orderStr = orderStr + r.ColumnName + " " + r.OrderDir + ",";
                }
                orderStr = orderStr.Trim(',');
                newCommandText = yourRegex.Replace(newCommandText, orderStr);
                return newCommandText;
            }
            return string.Empty;
        }

        public static string ConvertAdvanceFilterToConditionString(List<AdvanceFilterByModel> filtersList)
        {
            if(filtersList != null && filtersList.Count > 0)
            {
                var conditionString = "";
                foreach(var filter in filtersList)
                {
                    conditionString += " " + filter.Name;

                    switch (filter.Condition)
                    {
                        case GSEnums.ConditionENUM.Like:
                            conditionString += " LIKE " + "'%" + filter.Value + "%' AND ";
                            break;
                        case GSEnums.ConditionENUM.Equal:
                            conditionString += " = '" + filter.Value + "' AND ";
                            break;
                        case GSEnums.ConditionENUM.GreaterThan:
                            conditionString += " > '" + filter.Value + "' AND ";
                            break;
                        case GSEnums.ConditionENUM.LessThan:
                            conditionString += " < '" + filter.Value + "' AND ";
                            break;
                        case GSEnums.ConditionENUM.In:
                            conditionString += " IN (" + filter.Value + ") AND ";
                            break;
                    }
                }
                conditionString = conditionString.Substring(0, conditionString.Length - 4);
                return "  " + conditionString + "  ";
            }
            return string.Empty;
        }
    }
}
