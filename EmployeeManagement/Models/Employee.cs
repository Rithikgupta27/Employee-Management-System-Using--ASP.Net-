using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Name not given")]
        [StringLength(50)]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "City not given")]
        [StringLength(20)]
        public string City { get; set; }

        [Required(ErrorMessage = "Address not given")]
        [StringLength(100)]
        public string Address { get; set; }

         public static void Insert(Employee employee)
        {
             SqlConnection conn = new SqlConnection();
             conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
             try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Tbl_Emp values(@EmpName,@City,@Address)";
                //cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
        }
        public static void Update(Employee obj)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update Tbl_Emp set EmpName = @EmpName,City = @City,Address = @Address where EmpId = @id";
                cmd.Parameters.AddWithValue("@EmpId", obj.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", obj.EmpName);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
        }
        public static List<Employee> GetAll()
        {
           List< Employee> emp = new List<Employee>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Tbl_Emp";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Add(new Employee { EmpId = reader.GetInt32(0), EmpName = reader.GetString(1), City = reader.GetString(2), Address = reader.GetString(3)});
                }

            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return emp;
         }
          public static void Delete(int empNo) 
          {
            List<Employee> emp = new List<Employee>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from Tbl_Emp where EmpId = @empNo";
                cmd.Parameters.AddWithValue("@EmpId", empNo);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
        }
        public static Employee GetDetails(int empNo) {
          Employee employee = new Employee();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@EmpId", empNo);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Tbl_Emp where EmpId = @EmpId";
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    employee.EmpId = reader.GetInt32("EmpId");
                    employee.EmpName = reader.GetString("EmpName");
                    employee.City = reader.GetString("City");
                    employee.Address = reader.GetString("Address");
                cmd.ExecuteScalar();
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return employee;
        }
    }
    
}
