using AGSRProject.DataAccess.Contexts;
using Microsoft.Data.SqlClient;

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=AGSRProject;Trusted_Connection=True;";
using (var sqlConnection = new SqlConnection(connectionString))
{
    var query = string.Empty;

    for (int i = 0; i < 100; i++)
    {
        var index = i + 1;
        var id = Guid.NewGuid().ToString();
        string gender = string.Empty;

        var rnd = new Random();
        switch (rnd.Next(4))
        {
            case 0:
                gender = "male";
                break;
            case 1:
                gender = "female";
                break;
            case 2:
                gender = "other";
                break;
            case 3:
                gender = "unknown";
                break;
        }

        var year = rnd.Next(1990, 2024);
        var mounth = rnd.Next(1, 13);
        var day = mounth == 2 ? rnd.Next(1, 28) : rnd.Next(1, 30);
        var hour = rnd.Next(0, 24);
        var minute = rnd.Next(0, 60);
        var second = rnd.Next(0, 60);

        var birthDate = new DateTime(year, mounth, day, hour, minute, second).ToString();

        var activ = rnd.Next(0, 2);

        query += $"INSERT INTO Patients VALUES('{id}', 'official', 'Patient{index}', 'Patient{index}','Patient{index}', '{gender}', CONVERT(datetime, '{birthDate}', 103), '{activ}')";
    }

    sqlConnection.Open();
    SqlCommand cmd = new SqlCommand(query, sqlConnection);

    try
    {
        var reader = cmd.ExecuteReader();
        sqlConnection.Close();
    }
    catch (Exception ex)
    {
        sqlConnection.Close();
    }
}
