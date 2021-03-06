﻿using System.Collections.Generic;

namespace Email.DataProviders
{
    public class BaseDataProvider
    {
        public string BuildInsertStatement(string tableName, List<string> columns)
        {
            var cols = new List<string>();
            cols.AddRange(columns);
            cols.Add("IsActive");
            cols.Add("CreateDate");
            cols.Add("ModifiedDate");

            var result = "Insert into " + tableName + "(";
            for (var i = 0; i < cols.Count; i++)
            {
                result += "[" + cols[i] + "]";
                if (i != cols.Count - 1) { result += ","; }
            }
            result += ")values(";
            for (var i = 0; i < cols.Count; i++)
            {
                result += "@" + cols[i];
                if (i != cols.Count - 1) { result += ","; }
            }
            result += ")";
            return result;
        }

        public string BuildUpdateStatement(string tableName, List<string> columns, string Id="Id")
        {
            var cols = new List<string>();
            cols.AddRange(columns);
            cols.Add("ModifiedDate");
            var result = "Update " + tableName + " set";
            for (var i = 0; i < cols.Count; i++)
            {
                result += "[" + cols[i] + "] = @"+cols[i];
                if (i != cols.Count - 1) { result += ","; }
            }
            result += " where [" + Id + "] = @"+ Id;
            return result;
        }
    }
}
