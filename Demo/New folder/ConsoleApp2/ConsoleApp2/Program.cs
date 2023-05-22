using DemoSatva.Model;
using EasyCrudLibrary;

try
{
    var GSFramework = new EasyCrud("Server=db.satva.solutions,59763;Database=DemoSatva;User Id=sa;Password=Fishy1213#;");

    var em = new EventsModel()
    {
        Id = 1,
        EventTitle = "TEST",
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
        EventDescription = "DESC",
        EventPriority = 1
    };

    var g = GSFramework.Remove<EventsModel>(" WHERE Id IN (1541,1543) ", "Id", null, true);

    //var t = GSFramework.Query("Select * From Events");
    //var p = UtilityCustom.ConvertDynamicToType<List<EventsModel>>(t);

    //var h = GSFramework.Query("INSERT INTO [dbo].[Events] ([EventTitle] ,[StartDate] ,[EndDate] ,[EventDescription] ,[EventPriority]) VALUES ('asd' ,'1/1/1' ,'1/1/1' ,'1/1/1' ,1)", false, GSEnums.ExecuteType.ExecuteNonQuery);
    //GSFramework.SaveChanges();

    //var x = GSFramework.Add(em, "Id", "Id", false);
    //em.EventDescription = "v DESC";
    //var y = GSFramework.Add(em, "Id", "Id", true);
    //em.EventDescription = "X DESC";

    //var c1 = GSFramework.Count<EventsModel>(null, null, GSEnums.WithInQuery.ReadPast);
    //var c2 = GSFramework.Count<EventsModel>(null, null, GSEnums.WithInQuery.NoLock);

    //var b = GSFramework.Update(em, " Where Id = " + y, null, "Id", true);
    //var c = GSFramework.Update(em, " Where Id = " + x, null, "Id", false);
    //var g = GSFramework.Remove<EventsModel>(" WHERE Id = " + y, "Id", null, false);
    //var z = GSFramework.GetList<EventsModel>(-1, -1, null, null, null, GSEnums.WithInQuery.ReadPast);
    //var a = GSFramework.GetList<EventsModel>(-1, -1, null, null, null, GSEnums.WithInQuery.NoLock);
    GSFramework.SaveChanges();

}
catch (Exception ex)
{
    
}