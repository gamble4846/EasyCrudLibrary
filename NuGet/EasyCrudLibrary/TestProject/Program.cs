using EasyCrudLibrary;
using System.Data.SqlClient;
using TestProject;

var _EC = new EasyCrud("Server=dev2302.crystalsystems.work;Database=Acctivate$NAHSdev0306;User Id=sa;Password=ACCTivate!MSSQL;Max Pool Size=50000;Pooling=True;");
List<SqlParameter> Parameters = new List<SqlParameter>();
Parameters.Add(new SqlParameter("@MenuPageId", 12));

var model = new CtbRolePagePermissionModel()
{
    Id = 12,
    GUIDRole = new Guid(),
    PageId = 0,
    Allow = true,
};

var recs = _EC.Update(model, " WHERE Id = @MenuPageId ", Parameters, "Id, GUIDRole, PageId", true);

var x = recs;
