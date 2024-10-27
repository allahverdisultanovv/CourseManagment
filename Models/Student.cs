using CourseManagment.Services;

namespace CourseManagment.Models
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GroupNo { get; set; }
        public Group _Group { get; set; }
        public string Type { get; set; }

        public Student(string name, string surname, string groupNo, string type)
        {
            Name = name;
            Surname = surname;
            GroupNo = groupNo;
            Type = type;
            foreach (var group in GroupServices.Groups)
            {
                if (group.NO == groupNo)
                {
                    _Group = group;
                }
            }
        }
    }
}
