using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//These are the required imports.
using System.Windows.Media.Imaging;
using System.Data.SqlClient;


namespace CardDisplayTake3
{
    //public static class
    public static class Helper
    {
        public static BitmapImage GetImage(string path)
        {

            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            img.EndInit();

            return img;

        }
        //public static void InsertEvent(string someEvent)
        //{
        //    //try catch to handle any errors from connection and inserting into the database.
        //    try
        //    {
        //        //step 1 : get connection string from settings.
        //        string connectstring = Properties.Settings.Default.connectionString;
        //        //step 2: create a connection object.

        //        SqlConnection conn = new SqlConnection(connectstring);

        //        //Step 3: open that connection.
        //        conn.Open();

        //        //Getting current time to insert into database.
        //        DateTime eventDateTime = DateTime.Now;
        //        //Step 4: I need to create an SQL query.
        //        string InsertQuery = "INSERT INTO logs (event, timing) VALUES ('" + someEvent + "', '" + eventDateTime + "')";
        //        //Step 5: Create an SQL command.
        //        SqlCommand command = new SqlCommand(InsertQuery, conn);
        //        //Step 6: 
        //        command.ExecuteNonQuery();


                


        //    }catch(SqlException e)
        //    {


        //        Console.WriteLine(e.Message);
        //    }




        //}


    }
}
