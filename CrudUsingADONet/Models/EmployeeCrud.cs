using System.Data.SqlClient;

namespace CrudUsingADONet.Models
{
    public class EmployeeCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public EmployeeCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        // get all emp
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            cmd = new SqlCommand("select * from employee", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpId = Convert.ToInt32(dr["empid"]);
                    employee.Name = dr["name"].ToString();
                    employee.Email = dr["email"].ToString();
                    employee.Salary = Convert.ToDouble(dr["salary"]);
                    employees.Add(employee);
                }
            }
            con.Close();
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            cmd = new SqlCommand("select * from employee where empid=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employee.EmpId = Convert.ToInt32(dr["empid"]);
                    employee.Name = dr["name"].ToString();
                    employee.Email = dr["email"].ToString();
                    employee.Salary = Convert.ToDouble(dr["salary"]);

                }
            }
            con.Close();
            return employee;
        }

        public int AddEmployee(Employee emp)
        {
            int result = 0;
            string qry = "insert into employee values(@name,@email,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            string qry = "update employee set name=@name,email=@email,salary=@salary where empid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@id", emp.EmpId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from employee where empid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        internal string? GetStudents()
        {
            throw new NotImplementedException();
        }
    }

}
