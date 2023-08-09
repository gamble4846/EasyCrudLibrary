using EasyCrudLibrary;
using EasyCrudLibrary.Model;
using System.Data.SqlClient;
using TestProject;
using static EasyCrudLibrary.GSEnums;

var _EC = new EasyCrud("Server=dev2302.crystalsystems.work;Database=Acctivate$NAHSdev0306;User Id=sa;Password=ACCTivate!MSSQL;Max Pool Size=50000;Pooling=True;");
List<SqlParameter> Parameters = new List<SqlParameter>();
Parameters.Add(new SqlParameter("@MenuPageId", 12));

string[] test = { "1","2","3" };

var Filters = new List<AdvanceFilterByModel>();
Filters.Add(new AdvanceFilterByModel() { Condition = ConditionENUM.Like, Name = "Column1", Value = "Value1" });
Filters.Add(new AdvanceFilterByModel() { Condition = ConditionENUM.Equal, Name = "Column2", Value = "Value2" });
Filters.Add(new AdvanceFilterByModel() { Condition = ConditionENUM.GreaterThan, Name = "Column3", Value = "Value3" });
Filters.Add(new AdvanceFilterByModel() { Condition = ConditionENUM.LessThan, Name = "Column4", Value = "Value4" });
Filters.Add(new AdvanceFilterByModel() { Condition = ConditionENUM.In, Name = "Column5", Value = "'1','2','3'" });

var y = DataAccessHelper.ConvertAdvanceFilterToConditionString(Filters);

var model = new CtbRolePagePermissionModel()
{
    Id = 12,
    GUIDRole = new Guid(),
    PageId = 0,
    Allow = true,
};

var recs = _EC.Update(model, " WHERE Id = @MenuPageId ", Parameters, "Id, GUIDRole, PageId", true);

var x = recs;
