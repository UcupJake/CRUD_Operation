using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUD_Operation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Delete(DeleteUser delete)
        {
            string message = "";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=CRUD_Operation;User ID=sa;Password=goldensilk2020");
            connection.Open();
            SqlCommand command = new SqlCommand("delete UserTab where UserID = @UserID", connection);
            command.Parameters.AddWithValue("@UserID", delete.UID);
            int res = command.ExecuteNonQuery();
            if (res == 1)
            {
                message = "Data Berhasil Dihapus!";
            }
            else
            {
                message = "Data Tidak Berhasil Dihapus";
            }
            return message;
        }

        public gettestdata GetInfo()
        {
            gettestdata g = new gettestdata();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=CRUD_Operation;User ID=sa;Password=goldensilk2020");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from UserTab", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("mytab");
            dataAdapter.Fill(dataTable);
            g.usertab = dataTable;
            return g;
        }

        public string Insert(InsertUser user)
        {
            //return string.Format("You entered: {0}", value);

            string msg;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=CRUD_Operation;User ID=sa;Password=goldensilk2020");
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into UserTab (Name, Email) values(@Name, @Email)", connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);

            int g = command.ExecuteNonQuery();
            if(g==1)
            {
                msg = "Data Berhasil Dimasukkan!";
            }
            else
            {
                msg = "Data Tidak Berhasil Dimasukkan!";
            }
            return msg;
        }

        public string Update(UpdateUser update)
        {
            string Message = "";
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SU3D3TD;Initial Catalog=CRUD_Operation;User ID=sa;Password=goldensilk2020");
            connection.Open();
            SqlCommand command = new SqlCommand("Update UserTab set Name = @Name, Email = @Email where UserID= @UserID", connection);
            command.Parameters.AddWithValue("@UserID", update.UID);
            command.Parameters.AddWithValue("@Name", update.Name);
            command.Parameters.AddWithValue("@Email", update.Email);
            int res = command.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Data Berhasil Diperbaharui!";
            }
            else
            {
                Message = "Data Tidak Berhasil Diperbaharui!";
            }
            return Message;
        }

        //        public CompositeType GetDataUsingDataContract(CompositeType composite)
        //        {
        //            if (composite == null)
        //            {
        //                throw new ArgumentNullException("composite");
        //            }
        //            if (composite.BoolValue)
        //            {
        //                composite.StringValue += "Suffix";
        //            }
        //            return composite;
        //        }
    }
}
