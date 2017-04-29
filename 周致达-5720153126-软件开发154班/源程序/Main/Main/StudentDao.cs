using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Main
{
    class StudentDao//学生操作类
    {
        public static void studentMenu()//学生端主菜单
        {
            Console.Clear();
            Console.WriteLine("★★★★★学生端★★★★★\n");
            Console.WriteLine("→ 1 学生登录\n");
            Console.WriteLine("→ 2 学生注册\n");
            Console.WriteLine("→ 3 退出系统\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//跳转学生登录
            {
                studentLog();
            }
            else if (key.Key == ConsoleKey.D2)//跳转学生注册
            {
                studentReg();
            }
            else if (key.Key == ConsoleKey.D3)//退出系统
            {
                Console.WriteLine("\n*****已退出系统！*****\n");
                return;
            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }
        public static void studentReg()//学生注册
        {
            Console.WriteLine("\n\n◆◆◆学生注册◆◆◆\n");
            Console.WriteLine("请输入注册名字：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入注册密码：");
            string password = Console.ReadLine();
            Console.WriteLine("请输入学号：");
            string number = Console.ReadLine();
            Console.WriteLine("请输入班级：");
            string Class = Console.ReadLine();
            Student s = new Student(name, password,number,Class);
            ArrayList list = (ArrayList)GetList.getStudentList();//判断用户名是否存在
            int flag = 0;
            for (int i = 0; list != null && i < list.Count; i++)//第一次注册list为空 判断非空
            {
                Student n = (Student)list[i];
                if (s.getName().Equals(n.getName()))
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("*****该用户名已存在，请重新注册！*****");
                studentReg();
            }
            else
            {
                SetList.setList(s);//将对象写入文件
                Console.WriteLine("*****注册成功！*****");
                s.showInfo();
                Console.Write("\n→ 请登录：");//跳转至学生登录
                studentLog();
            }
        }
        public static void studentLog()//学生登录
        {
            Console.WriteLine("\n\n◆◆◆学生登录◆◆◆\n");
            Console.WriteLine("请输入名字：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            ArrayList list = (ArrayList)GetList.getStudentList();//判断账户是否存在
            int flag = 0;
            int isExist = 0;
            for (int i = 0; list != null&&i < list.Count; i++)
            {
                if (flag == 1) break;
                Student n = (Student)list[i];
                if (n.getName().Equals(name) && n.getPassword().Equals(password))//登陆成功
                {
                    flag = 1;
                    isExist = 1;
                    Student s = n;//获取当前登录对象
                    managerStudent(s);//跳转至学生信息处理
                }
            }
            if (isExist == 0)
            {
                Console.WriteLine("*****名称或密码有误，请重新登录！*****");
                studentLog();
            }
        }
        public static void managerStudent(Student stu)//学生信息操作菜单
        {
            Student s = stu;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆学生管理菜单◆◆◆◆◆\n");
            Console.WriteLine("→ 1 查看我的宿舍信息\n");
            Console.WriteLine("→ 2 查看我的个人信息\n");
            Console.WriteLine("→ 3 修改我的登录密码\n");
            Console.WriteLine("→ 4 退出系统\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//跳转至查看我的宿舍信息
            {
                showMyHouse(s);   
            }
            else if (key.Key == ConsoleKey.D2)//跳转至查看我的个人信息
            {
                showMyInfo(s);
            }
            else if (key.Key == ConsoleKey.D3)//跳转至修改我的登录密码
            {
                changeMyPassword(s);
            }
            else if (key.Key == ConsoleKey.D4)//退出系统
            {
                Console.WriteLine("\n*****已退出系统！*****\n");
                return;
            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }

        public static void showMyHouse(Student stu)//查询学生宿舍信息
        {
            Student s = stu;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆学生宿舍查询◆◆◆◆◆\n");
            Console.WriteLine("请输入你的姓名、学号或班级进行查询：");
            Console.ReadLine();
            Hashtable hs = (Hashtable)GetList.getHouseTable();
            if (hs != null)
            {
                int flag = 0;
                foreach (DictionaryEntry i in hs)
                {
                    if (flag == 1) break;
                    ArrayList list = (ArrayList)i.Value;//获取学生对象集合
                    for (int j = 0; j < list.Count; j++)
                    {
                        Student ss = (Student)list[j];
                        if (ss.getName().Equals(s.getName()))//找到该学生对象
                        {
                            flag = 1;
                            string house_id = (string)i.Key;
                            Console.WriteLine("-----你的宿舍信息如下：-----");
                            Console.WriteLine("      宿舍号：" + house_id);
                            Console.Write("      宿舍成员：");
                            for (int k = 0; k < list.Count; k++)
                            {
                                Student sss = (Student)list[k];
                                Console.Write(sss.getName() + "  ");
                            }
                            Console.WriteLine("\n");
                        }
                    }
                }
            }
            Console.WriteLine("→ 1 查看我的个人信息\n");//后续操作
            Console.WriteLine("→ 2 返回学生主菜单\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//查看我的个人信息
            {
                showMyInfo(s);
            }
            else if (key.Key == ConsoleKey.D2)//返回学生主菜单
            {
                managerStudent(s);

            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }
        public static void showMyInfo(Student stu)//查询学生个人信息
        {
            Student s = stu;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆我的个人信息如下◆◆◆◆◆：\n");
            s.showInfo();
            Console.WriteLine();
            Console.WriteLine("→ 1 查看我的宿舍信息\n");//后续操作
            Console.WriteLine("→ 2 返回学生主菜单\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//查看我的宿舍信息
            {
                showMyHouse(s);
            }
            else if (key.Key == ConsoleKey.D2)//返回学生主菜单
            {
                managerStudent(s);

            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }
        public static void changeMyPassword(Student stu)//修改学生密码
        {
            Student s = stu;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆修改密码◆◆◆◆◆\n");
            Console.WriteLine("请输入新密码：");
            string ps = Console.ReadLine();
            ArrayList list = (ArrayList)GetList.getStudentList();
            int flag = 0;
            for (int i = 0; i < list.Count; i++)//查到该学生对象
            {
                if (flag == 1) break;
                Student ss = (Student)list[i];
                if (ss.getName().Equals(s.getName()))
                {
                    s = ss;//更新当前对象
                    s.setPassword(ps);//改密
                    list.Remove(ss);//将之前的旧对象移除
                    flag = 1;
                }
            }
            SetList.setStudentList(list);//更新集合
            SetList.setList(s);//更新学生信息
            Console.WriteLine("\n*****密码修改成功！ 你的新密码是：" + s.getPassword()+"*****\n");
            Console.WriteLine("→ 1 查看我的宿舍信息\n");//后续操作
            Console.WriteLine("→ 2 查看我的个人信息\n");
            Console.WriteLine("→ 3 返回学生主菜单\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//查看我的宿舍信息
            {
                showMyHouse(s);
            }
            else if (key.Key == ConsoleKey.D2)//查询个人信息
            {
                showMyInfo(s);

            }
            else if (key.Key == ConsoleKey.D3)//返回学生主菜单
            {
                managerStudent(s);

            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }
    }
}
