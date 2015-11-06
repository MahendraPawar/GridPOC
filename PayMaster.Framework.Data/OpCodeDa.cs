using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using PayMaster.Framework.Data.sql;
using PayMaster.Framework.Data.StoredProcedureNames;
using PayMaster.Framework.Model;
using PayMaster.Framework.Utility.Static;

namespace PayMaster.Framework.Data
{
    public class OpCodeDa : BaseDa
    {
        public static ICollection<OpCode> Get(OpCode obj)
        {
            ProcQuery = SpNameList.UspGetOpCodeList;
            ConnString = ConfigStatic.PskwConnectionstring;
            if (obj.OpcodeId > 0)
            {
                ListSqlParameters.Add(new SqlParameter("@OpcodeID ", obj.OpcodeId));
            }

            var dt = SqlHelper.ExecuteStoredProcedure<DataTable>(ConnString, ProcQuery, ListSqlParameters);

            return SqlHelper.DataTableToList<OpCode>(dt);

            //return (from DataRow row in dt.Rows
            //        select new OpCode
            //        {
            //            OpcodeId = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["OpcodeID"])) ? CultureInfoFormat.ToInt64(row["OpcodeID"]) : 0,
            //            OpcodeName = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["OpcodeName"])) ? CultureInfoFormat.ToString(row["OpcodeName"]) : string.Empty,
            //            OpcodeDescription = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["OpcodeDescription"])) ? CultureInfoFormat.ToString(row["OpcodeDescription"]) : string.Empty,
            //            ProgramId = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["ProgramID"])) ? CultureInfoFormat.ToString(row["ProgramID"]) : string.Empty,
            //            UpdatedDate = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["UpdatedDate"])) ? CultureInfoFormat.ToString(CultureInfoFormat.ToDateTime(row["UpdatedDate"])) : string.Empty,
            //            IsActive = !string.IsNullOrEmpty(CultureInfoFormat.ToString(row["IsActive"])) && CultureInfoFormat.ToBoolean(row["IsActive"]),
            //        }).ToList();
        }

        public static OpCode AddOrUpdate(OpCode obj)
        {
            ProcQuery = SpNameList.UspInsertOrUpdate;
            ConnString = ConfigStatic.PskwConnectionstring;

            if (obj.OpcodeId > 0)
            {
                ListSqlParameters.Add(new SqlParameter("@OpcodeID ", obj.OpcodeId));
            }

            ListSqlParameters.Add(new SqlParameter("@OpcodeName ", obj.OpcodeName));
            ListSqlParameters.Add(new SqlParameter("@OpcodeDescription ", obj.OpcodeDescription));
            ListSqlParameters.Add(new SqlParameter("@ProgramID ", obj.ProgramId));
            ListSqlParameters.Add(new SqlParameter("@UpdatedDate ", DateTime.Now));
            ListSqlParameters.Add(new SqlParameter("@IsActive ", !obj.IsActive));

            //0 for add or insert
            ListSqlParameters.Add(new SqlParameter("@OpFlag", SqlDbType.Int)
                                  {
                                      Value = 0
                                  });

            //var outPut = new SqlParameter("@OutStatus", SqlDbType.Int) { Direction = ParameterDirection.Output };
            //ListSqlParameters.Add(outPut);

            var dt = SqlHelper.ExecuteStoredProcedure<DataTable>(ConnString, ProcQuery, ListSqlParameters);

            return SqlHelper.DataTableToList<OpCode>(dt).FirstOrDefault();
            //return CultureInfoFormat.ToInt32(outPut.Value);
        }

        public static OpCode Delete(OpCode obj)
        {
            ProcQuery = SpNameList.UspInsertOrUpdate;
            ConnString = ConfigStatic.PskwConnectionstring;
            ListSqlParameters.Add(new SqlParameter("@OpcodeID ", obj.OpcodeId));
            ListSqlParameters.Add(new SqlParameter("@IsActive ", obj.IsActive));

            //1 for Delete
            ListSqlParameters.Add(new SqlParameter("@OpFlag ", 1));

            var dt = SqlHelper.ExecuteStoredProcedure<DataTable>(ConnString, ProcQuery, ListSqlParameters);

            return SqlHelper.DataTableToList<OpCode>(dt).FirstOrDefault();
        }

        public static ICollection<SelectListItem> GetProgramList()
        {
            var obj = new Collection<SelectListItem>
                      {
                          new SelectListItem()
                          {
                              Text = "Program1",
                              Value = "1"
                          },
                          new SelectListItem()
                          {
                              Text = "Program2",
                              Value = "2"
                          },
                          new SelectListItem()
                          {
                              Text = "Program3",
                              Value = "3"
                          },
                          new SelectListItem()
                          {
                              Text = "Program4",
                              Value = "4"
                          },
                      };

            return obj;
        }
    }
}
