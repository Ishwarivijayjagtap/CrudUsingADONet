using System.Data.SqlClient;

namespace CrudUsingADONet.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        // get all emp
        public List<Student> GetStudents()
        {
            List<Student> student = new List<Student>();
            cmd = new SqlCommand("select * from Student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student stud = new Student();
                    stud.RollNo = Convert.ToInt32(dr["rollno"]);
                    stud.Name = dr["name"].ToString();

                    stud.Percentage = Convert.ToInt32(dr["percentage"]);
                    stud.Branch = dr["branch"].ToString();

                    student.Add(stud);
                }
            }
            con.Close();
            return student;
        }
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("select * from student where rollno=@rollno", con);
            cmd.Parameters.AddWithValue("@rollno", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Percentage = Convert.ToInt32(dr["percentage"]);
                    student.Branch = dr["branch"].ToString();
                }
            }
            con.Close();
            return student;
        }

        public int AddStudent(Student std)
        {
            int result = 0;
            string qry = "insert into student values(@name,@percentage,@branch)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            cmd.Parameters.AddWithValue("@branch", std.Branch);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student std)
        {
            int result = 0;
            string qry = "update student set name=@name,percentage=@percentage,branch=@branch where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            cmd.Parameters.AddWithValue("@branch", std.Branch);
            cmd.Parameters.AddWithValue("@rollno", std.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
