using CourseManagment.Enums;
using CourseManagment.Models;

namespace CourseManagment.Services
{
    internal class GroupServices
    {
        public static List<Group> Groups = new();

        //common methods
        public bool CheckNO(string no)
        {
            foreach (var group in Groups)
            {
                if (group.NO == no)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSolt(string no)
        {
            foreach (var group in Groups)
            {
                if (group.NO == no && group.Students.Length < group.Limit)
                {
                    return true;
                }
            }
            return false;

        }
        public void GetGroupStudents(Group group)
        {
            foreach (var student in group.Students)
            {
                Console.WriteLine($"Name: {student.Name}  Surname: {student.Surname} Group: {student.GroupNo} Is Online :{group.IsOnline}");

            }
        }

        //Case 1 methods
        public void CreateGroup(string no, string cat, bool isonline)
        {

            Groups.Add(new Group(no, cat, isonline));
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{no}   Grupu Yarandi\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Click any button for continue");
            Console.ReadLine();
            Console.Clear();

        }
        public string GetCategory(ref string no)
        {
            string cat = "";
        IfCatIsIncorrect: Console.WriteLine("Category secin\n\n1.Programming\n2.Deesign\n3.System Adminstration");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    cat = Categories.Programming.ToString();
                    no = "P";
                    break;
                case "2":
                    cat = Categories.Design.ToString();
                    no = "D";
                    break;
                case "3":
                    cat = Categories.SystemAdminstration.ToString();
                    no = "S";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Secim yanlisdir");
                    goto IfCatIsIncorrect;

            }
            Console.Clear();
            return cat;
        }
        public void SetGroupNo(ref string no)
        {
        GroupNoIsIncorrect: Console.WriteLine("Grup nomresi Daxil edin(Yalniz reqemler)");
            string option = Console.ReadLine();
            option = option.Trim();
            if (option == "")
            {
                Console.Clear();
                Console.WriteLine("Qrup adi duzgun deyil Yenidn daxil edin");
                goto GroupNoIsIncorrect;

            }
            foreach (var ch in option)
            {
                if (!Char.IsDigit(ch))
                {
                    Console.Clear();
                    Console.WriteLine("Qrup no yalniz reqem olmalidir");
                    goto GroupNoIsIncorrect;
                }
            }
            if (GroupServices.Groups.Count == 0)
            {
                no += option;
            }
            else if (!CheckNO(option))
            {
                no += option;
            }
            else
            {
                Console.WriteLine("Bu adda qrup artiq movcuddur");
                goto GroupNoIsIncorrect;

            }

            Console.Clear();

        }
        public void SetIsOnline(ref bool isOnline)
        {
        IfIsOnlineIsIncorrect: Console.WriteLine("Tehsil novunu secin\n\n1.Online\n2.Eyani");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    isOnline = true;
                    break;
                case "2":
                    isOnline = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Secim yanlisdir");

                    goto IfIsOnlineIsIncorrect;
            }
            Console.Clear();
        }


        //Case 2 methods
        public void ShowAllGroups()
        {
            Console.Clear();
            Console.WriteLine("\nGroups:");
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            foreach (var group in Groups)
            {

                Console.WriteLine($"Name:{group.NO}, Category:{group.Category}, Limit:{group.Limit} ");
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\nClick the any button for contunie\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ReadLine();
            Console.Clear();
        }

        //Case 3 methods
        public void UpdateGroupNo()
        {
        ChosenGroupNoIsIncorrect: Console.WriteLine("Hansi qrupda deyisiklik etmek istirsen");
            string groupNo = Console.ReadLine();
            string updatedNo = "";
            string newNo;
            if (CheckNO(groupNo))
            {
                newNo = groupNo.Substring(0, 1);
            GroupNoIsIncorrect: Console.WriteLine("Yeni Grup nomresi Daxil edin(Yalniz reqemler)");
                updatedNo = Console.ReadLine();
                updatedNo = updatedNo.Trim();
                if (updatedNo == "")
                {
                    Console.Clear();
                    Console.WriteLine("Grup nomresi duzgun deyil Yenidn daxil edin");
                    goto GroupNoIsIncorrect;

                }
                foreach (var ch in updatedNo)
                {
                    if (!Char.IsDigit(ch))
                    {
                        Console.Clear();
                        Console.WriteLine("Qrup no yalniz reqem olmalidir");
                        goto GroupNoIsIncorrect;
                    }
                }

            }
            else
            {
                Console.WriteLine("Bu adda qrup movcud deyil");
                goto ChosenGroupNoIsIncorrect;
            }

            newNo += updatedNo;
            foreach (var group in Groups)
            {
                if (group.NO == groupNo)
                {
                    group.NO = newNo;
                }
            }
            //foreach (var item in Groups)
            //{
            //    foreach (var student in item.Students)
            //    {
            //        student.GroupNo = newNo;
            //    }
            //}
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Group updated\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Click any button for continue");
            Console.ReadLine();
            Console.Clear();


        }


        //Case  4 methods
        public void ShowGroupStudents()
        {
            Console.Clear();
            Console.WriteLine("\nGormek istediyiniz qrupun adin daxil edin\n");
            string groupno = Console.ReadLine();
            if (!CheckNO(groupno))
            {
                Console.WriteLine("Bu adda qrup movcud deyil\n\nClick Any button");
                Console.ReadLine();

                return;
            }
            foreach (var group in Groups)
            {
                if (group.NO == groupno)
                {
                    Console.WriteLine($"{group.NO}:\n");
                    GetGroupStudents(group);
                }
            }

        }

        //Case 5
        public void ShowAllStudents()
        {
            foreach (var group in Groups)
            {
                GetGroupStudents(group);
            }
        }
        //Case 6 methods
        public void CreateStudent(string name, string surname, string groupNo, string type)
        {
            Student student = new(name, surname, groupNo, type);
            foreach (var group in Groups)
            {
                if (group.NO == groupNo)
                {

                    Array.Resize(ref group.Students, group.Students.Length + 1);
                    group.Students[group.Students.Length - 1] = student;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Student Created\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Click any button for continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        }
        public void GetStudentGroupName(ref string groupno)
        {
            Console.Clear();
        GroupNameIsIncorrect: Console.WriteLine("Qrupunuzun adin daxil edin");
            groupno = Console.ReadLine().Trim();
            if (!CheckNO(groupno))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Bele grup yoxdur");
                Console.BackgroundColor = ConsoleColor.Black;
                goto GroupNameIsIncorrect;
            }
            else if (!CheckSolt(groupno))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("bu Qrupda yer yoxdur");
                Console.BackgroundColor = ConsoleColor.Black;
                goto GroupNameIsIncorrect;
            }
            Console.WriteLine(groupno);
            Console.Clear();
        }
        public void GetStudentName(ref string name)
        {
        NameIsIncorrect: Console.WriteLine("Adinizi daxil edin");
            name = Console.ReadLine().Trim();
            if (name.Length < 3)
            {
                Console.WriteLine("Adiniz yeterince uzunluga malik deyil");
                goto NameIsIncorrect;
            }

            foreach (var ch in name)
            {
                if (!Char.IsLetter(ch))
                {
                    Console.WriteLine("Adda yalniz herfler olmalidi");
                    goto NameIsIncorrect;
                }
            }
        }
        public void GetStudentSurname(ref string surname)
        {
        SurnameIsIncorrect: Console.WriteLine("Soy adinizi daxil edin");
            surname = Console.ReadLine().Trim();
            if (surname.Length < 3)
            {
                Console.WriteLine("Soyadiniz yeterince uzunluga malik deyil");
                goto SurnameIsIncorrect;
            }

            foreach (var ch in surname)
            {
                if (!Char.IsLetter(ch))
                {
                    Console.WriteLine("Soyadda yalniz herfler olmalidi");
                    goto SurnameIsIncorrect;
                }
            }
        }
        public void GetStudentType(ref string type)
        {
        TpyeIsIncorrect: Console.WriteLine("Zemanetiniz varmi?\nVarsa 1 secimin secin\nYoxdursa 2 secimin secin");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    type = "Zemanetli";
                    break;
                case "2":
                    type = "Zemantesiz";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Yanlis Secim");
                    goto TpyeIsIncorrect;

            }
        }
    }
}
