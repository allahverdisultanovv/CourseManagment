namespace CourseManagment.Models
{
    internal class Group
    {
        public string NO { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }
        public Student[] Students = new Student[0];

        public Group(string no, string category, bool isOnline)
        {
            NO = no;
            Category = category;
            IsOnline = isOnline;
            if (isOnline)
            {
                Limit = 15;
            }
            else
            {
                Limit = 10;
            }
        }
    }
}
