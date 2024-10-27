using CourseManagment.Services;

GroupServices groupService = new GroupServices();

string answer;
do
{

ReturnMenu: Console.WriteLine("1.Grup yarat\n2.Gruplarin siyahisini goster\n3.Qrup uzerinda duzelish etmek\n4.Grup telebelerinin siyahisi\n5.All students\n6.Telebe yarat\n\n\n0.Cixish");
    answer = Console.ReadLine().Trim();

    switch (answer)
    {


        case "1":
            Console.Clear();
            string no = "";
            string cat = "";
            bool isOnline = false;
            cat = groupService.GetCategory(ref no);
            groupService.SetGroupNo(ref no);
            groupService.SetIsOnline(ref isOnline);
            groupService.CreateGroup(no, cat, isOnline);

            break;

        case "2":
            groupService.ShowAllGroups();
            break;

        case "3":
            groupService.UpdateGroupNo();
            break;

        case "4":
            groupService.ShowGroupStudents();
            break;
        case "5":
            groupService.ShowAllGroups();
            break;
        case "6":
            string name = "";
            string surname = "";
            string groupno = "";
            string type = "";

            groupService.GetStudentGroupName(ref groupno);
            groupService.GetStudentName(ref name);
            groupService.GetStudentSurname(ref surname);
            groupService.GetStudentType(ref type);
            groupService.CreateStudent(name, surname, groupno, type);
            break;
        case "0":
            break;
        default:
            break;
    }



} while (answer != "0");
Console.Clear();
//Console.WriteLine($"{GroupServices.Groups[0].NO},  {GroupServices.Groups[0].Category}, {GroupServices.Groups[0].IsOnline}, {GroupServices.Groups[0].Limit}");