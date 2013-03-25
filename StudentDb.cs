using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;


namespace SaturdayM23
{
    //connect...disconnect
    public class StudentDb
    {
        private string constr;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public StudentDb()
        {
            constr = ConfigurationSettings.AppSettings["constr"];
            con=new SqlConnection();
            con.ConnectionString = constr;

            cmd=new SqlCommand();
            cmd.Connection = con;
            reader = null;

        }

        public void Connect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Server name error");                
            }
            
        }

        public void Disconnect()
        {
            
                if (con.State == ConnectionState.Open)
                    con.Close();
            

            
        }
        public int Insert(Student s)
        {
            //int res = -1;


            //this.cmd.CommandText = "insert into student (Name,Roll,Age) values(@Name,@Roll,@Age)";
            //this.cmd.Parameters.AddWithValue("@Name", s.Name);
            //this.cmd.Parameters.AddWithValue("@Age", s.Age);
            //this.cmd.Parameters.AddWithValue("@Roll", s.Roll);

            //Connect();

            //try
            //{
            //    res = cmd.ExecuteNonQuery();

            //}
            //catch (SqlException se)
            //{
            //    Console.WriteLine(se.Message);
            //    res = -1;
            //}

            //this.Disconnect();

            //return res;

            string query = "insert into student (Name,Roll,Age) values('"+s.Name+"',"+s.Roll+","+s.Age+")";

            int result=this.InsertUpdateDelete(query);
            return result;


        }

        public int Delete(int sn)
        {
            //Connect();
            //cmd.CommandText = "Delete from Student where SN=@sn";
            //cmd.Parameters.AddWithValue("@sn", sn);
            //int res=cmd.ExecuteNonQuery();

            //Disconnect();
            //return res;

            string query = "Delete from Student where SN="+sn;
            int result=this.InsertUpdateDelete(query);
            return result;

        }

        public int Update(Student s)
        {
            //int res = -1;


            //this.cmd.CommandText = "Update Student set Name=@Name, Roll=@Roll,Age=@Age where SN=@SN";
            //this.cmd.Parameters.AddWithValue("@Name", s.Name);
            //this.cmd.Parameters.AddWithValue("@Age", s.Age);
            //this.cmd.Parameters.AddWithValue("@Roll", s.Roll);
            //this.cmd.Parameters.AddWithValue("@SN", s.Sn);

            //Connect();

            //try
            //{
            //    res = cmd.ExecuteNonQuery();

            //}
            //catch (SqlException se)
            //{
            //    Console.WriteLine(se.Message);
            //    res = -1;
            //}

            //this.Disconnect();

            //return res;
            //"update student set name='"+s.Name+"', roll="+s.Roll=", age=20 where sn=1"
            string query = "Update Student set Name='"+s.Name+"', Roll="+s.Roll+",Age="+s.Age+" where SN="+s.Sn;

            int result=this.InsertUpdateDelete(query);
            return result;


        }

        public int InsertUpdateDelete(String query)
        {
            int res = -1;

            cmd.CommandText = query;

            Connect();

            try
            {
                res = cmd.ExecuteNonQuery();

            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                res = -1;
            }

            this.Disconnect();

            return res;


        }

        public List<Student> SelectAll()
        {
            List<Student> list=new List<Student>();

            cmd.CommandText = "select * from Student";

            this.Connect();

            try
            {
                reader=cmd.ExecuteReader();
            }

            catch(SqlException se)
            {
                Console.WriteLine(se.Message);
            }

            while(reader.Read())
            {
                Student temp=new Student();
                temp.Sn = Convert.ToInt32(reader["SN"]);
                temp.Name = Convert.ToString(reader["Name"]);
                temp.Age = Convert.ToInt32(reader["Age"]);
                temp.Roll = Convert.ToInt32(reader["Roll"]);
                list.Add(temp);
            }
            return list;
        }
    }
}
