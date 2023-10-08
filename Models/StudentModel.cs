namespace StudentMVC.Models
{
    public interface IStudentModel
    {
        List<Student> GetStudents();
        Student? GetStudentById(int id);
        void AddNewStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }

    public class StudentModel : IStudentModel
    {
        private readonly DataContext _context;

        public StudentModel(DataContext context){
            this._context = context;
        }
        public void AddNewStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}