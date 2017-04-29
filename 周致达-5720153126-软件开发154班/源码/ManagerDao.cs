using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Main
{
    class ManagerDao//宿管操作类
    {
        public static void managerMenu()//宿管端主菜单
        {
            Console.Clear();//清屏
            Console.WriteLine("★★★★★★宿管端★★★★★★\n");
            Console.WriteLine("→ 1 宿管登录\n");
            Console.WriteLine("→ 2 宿管注册\n");
            Console.WriteLine("→ 3 退出系统\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//跳转宿管登录
            {
                managerLog();
            }
            else if (key.Key == ConsoleKey.D2)//跳转宿管注册
            {
                managerReg();
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
        public static void managerReg()//宿管注册
        {
            Console.WriteLine("\n\n◆◆◆宿管注册◆◆◆\n");
            Console.WriteLine("请输入注册名字：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入注册密码：");
            string password = Console.ReadLine();
            Manager m = new Manager(name,password);
            ArrayList list = (ArrayList)GetList.getManagerList();//判断用户名是否存在
            int flag = 0;
            for (int i = 0; list != null&&i < list.Count; i++)//判断list非空
            {   
                Manager n=(Manager)list[i];
                if (m.getName().Equals(n.getName()))
                {
                    flag=1;
                }
            }
            if (flag == 1)
            {
                Console.Write("*****该用户名已存在，请重新注册！*****");
                managerReg();
            }
            else
            {
                SetList.setList(m);//将对象写入文件
                Console.WriteLine("*****注册成功！*****");
                m.showInfo();
                Console.Write("\n→ 请登录：");//跳转至宿管登录
                managerLog();
            }
        }
        public static void managerLog()//宿管登录
        {
            Console.WriteLine("\n\n◆◆◆宿管登录◆◆◆\n");
            Console.WriteLine("请输入名字：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            ArrayList list = (ArrayList)GetList.getManagerList();//判断账户是否存在
            int flag = 0;
            int isExist = 0;
            for (int i = 0; list != null&&i < list.Count; i++)
            {
                if (flag == 1) break;
                Manager n = (Manager)list[i];
                if (n.getName().Equals(name) && n.getPassword().Equals(password))//登陆成功
                {
                    flag =1;
                    isExist = 1;
                    Manager m = n;//获取当前登录的宿管对象
                    managerHouse(m);//登陆成功 跳转至宿舍管理主菜单
                }
            }
            if (isExist == 0)
            {
                Console.WriteLine("*****名称或密码有误，请重新登录！*****");
                   managerLog();
            }
        }
        public static void managerHouse(Manager man)//宿管操作菜单
        {
            Manager m = man;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆宿管管理菜单◆◆◆◆◆\n");
            Console.WriteLine("→ 1 增加宿舍\n");
            Console.WriteLine("→ 2 删除宿舍\n");
            Console.WriteLine("→ 3 修改宿舍\n");
            Console.WriteLine("→ 4 查看所有宿舍信息\n");
            Console.WriteLine("→ 5 退出系统\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//跳转至增加宿舍
            {
                addHouse(m);
            }
            else if (key.Key == ConsoleKey.D2)//跳转至删除宿舍
            {
                deleteHouse(m);

            }
            else if (key.Key == ConsoleKey.D3)//跳转至修改宿舍
            {
                changeHouse(m);
            }
            else if (key.Key == ConsoleKey.D4)//跳转至查询所有宿舍
            {
                selectHouse(m);
            }
            else if (key.Key == ConsoleKey.D5)//退出系统
            {
                Console.WriteLine("\n*****已退出系统！*****\n");
                return;
            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }

        public static void addHouse(Manager man)//添加宿舍
        {
            Manager m = man;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆增加宿舍◆◆◆◆◆\n");
            Console.WriteLine("请输入要增加的宿舍号：");
            string house_id = Console.ReadLine();
            Console.WriteLine("请输入要增加的学生姓名：");
            string stu_name = Console.ReadLine();
            ArrayList list = (ArrayList)GetList.getStudentList(); //根据姓名查出学生对象
            Student s = null;
            int flag = 0;
            for (int i = 0; list != null && i < list.Count; i++)//查询学生对象
            {
                Student n = (Student)list[i];
                if (n.getName().Equals(stu_name))
                {
                    flag = 1;
                    s = n;
                }
            }
            Hashtable hs = (Hashtable)GetList.getHouseTable();
            if (hs != null && hs.Contains(house_id))//宿舍号已存在
            {
                Console.WriteLine("\n*****该宿舍号已经存在,创建失败!*****\n");
                Console.WriteLine("→ 1 重新添加宿舍\n");//后续操作
                Console.WriteLine("→ 2 返回宿管主菜单\n");
                Console.WriteLine("请选择操作：");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)//重新增加宿舍
                {
                    addHouse(m);
                }
                else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                {
                    managerHouse(m);

                }
                else
                {
                    Console.WriteLine("\n*****操作有误！*****\n");
                }
            }
            else//宿舍号不存在
            {
                if (flag == 1)//能查到该学生
                {
                    //判断学生是否存在于其他的宿舍
                    bool isExist = false;
                    int flag1 = 0;
                    if (hs != null)
                    {
                        foreach (DictionaryEntry i in hs)
                        {
                            if (flag1 == 1) break;
                            ArrayList ls = (ArrayList)i.Value;//得到hashtable的arraylist集合
                            for (int j = 0; j < ls.Count; j++)
                            {
                                Student ss = (Student)ls[j];
                                if (ss.getName().Equals(s.getName()))
                                {
                                    flag1 = 1;
                                    isExist = true;
                                }
                            }
                        }
                    }
                    if (isExist)//该学生存在其他宿舍
                    {
                        string exist_House_Id = "";
                        int flag2 = 0;
                        foreach (DictionaryEntry i in hs)//查询出该学生存在于哪个宿舍
                        {
                            if (flag2 == 1) break;
                            ArrayList ls = (ArrayList)i.Value;//得到hashtable的arraylist集合
                            for (int j = 0; j < ls.Count; j++)
                            {
                                Student ss = (Student)ls[j];
                                if (ss.getName().Equals(s.getName()))
                                {
                                    exist_House_Id = (string)i.Key;
                                    flag2 = 1;
                                }
                            }

                        }
                        Console.WriteLine("\n*****该学生已在" + exist_House_Id + "宿舍,创建失败!*****\n");
                        Console.WriteLine("→ 1 重新添加宿舍\n");
                        Console.WriteLine("→ 2 返回宿管主菜单\n");
                        Console.WriteLine("请选择操作：");
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.D1)//重新增加宿舍
                        {
                            addHouse(m);
                        }
                        else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                        {
                            managerHouse(m);

                        }
                        else
                        {
                            Console.WriteLine("\n*****操作有误！*****\n");
                        }
                    }
                    else//该学生不在其他宿舍
                    {
                        ArrayList ls = new ArrayList();
                        ls.Add(s);
                        SetList.setHouseTable(house_id, ls);//将宿舍信息序列化 
                        Console.WriteLine("\n*****宿舍创建成功！*****\n");
                        Console.WriteLine("→ 1 继续添加宿舍\n");
                        Console.WriteLine("→ 2 返回宿管主菜单\n");
                        Console.WriteLine("请选择操作：");
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.D1)//继续增加宿舍
                        {
                            addHouse(m);
                        }
                        else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                        {
                            managerHouse(m);

                        }
                        else
                        {
                            Console.WriteLine("\n*****操作有误！*****\n");
                        }
                    }
                }
                else//不能查到该学生
                {
                    Console.WriteLine("\n*****该学生还未注册,,创建失败！*****\n");
                    Console.WriteLine("→ 1 重新添加宿舍\n");
                    Console.WriteLine("→ 2 返回宿管主菜单\n");
                    Console.WriteLine("请选择操作：");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)//重新增加宿舍
                    {
                        addHouse(m);
                    }
                    else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                    {
                        managerHouse(m);

                    }
                    else
                    {
                        Console.WriteLine("\n*****操作有误！*****\n");
                    }
                }
            }
        }
        public static void deleteHouse(Manager man)//删除宿舍
        {
            Manager m = man;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆删除宿舍◆◆◆◆◆\n");
            Console.WriteLine("→ 1 删除一个宿舍\n");
            Console.WriteLine("→ 2 删除所有宿舍\n");
            ConsoleKeyInfo key1 = Console.ReadKey();
            if (key1.Key == ConsoleKey.D1)//删除一个宿舍
            {
                Console.WriteLine("\n请输入要删除的宿舍号：");
                string house_id = Console.ReadLine();
                Hashtable hs = (Hashtable)GetList.getHouseTable();
                if (hs.ContainsKey(house_id))//判断输入的宿舍号是否存在
                {
                    hs.Remove(house_id);//从table中移除
                    SetList.setHouseTable(hs);//将修改后的宿舍信息序列化保存
                    Console.WriteLine("\n*****宿舍删除成功！*****\n");
                    Console.WriteLine("→ 1 继续删除宿舍\n");
                    Console.WriteLine("→ 2 返回宿管主菜单\n");
                    Console.WriteLine("请选择操作：");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)//继续删除宿舍
                    {
                        deleteHouse(m);
                    }
                    else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                    {
                        managerHouse(m);

                    }
                    else
                    {
                        Console.WriteLine("\n*****操作有误！*****\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n*****你输入的宿舍号不存在，宿舍删除失败！*****\n");
                    Console.WriteLine("→ 1 重新删除宿舍\n");
                    Console.WriteLine("→ 2 返回宿管主菜单\n");
                    Console.WriteLine("请选择操作：");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)//重新删除宿舍
                    {
                        deleteHouse(m);
                    }
                    else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                    {
                        managerHouse(m);

                    }
                    else
                    {
                        Console.WriteLine("\n*****操作有误！*****\n");
                    }
                }
            }
            else if (key1.Key == ConsoleKey.D2)//删除所有宿舍
            {
                Hashtable hs = (Hashtable)GetList.getHouseTable();
                hs.Clear();//清除所有宿舍
                SetList.setHouseTable(hs);//保存更改
                Console.WriteLine("\n*****所有宿舍删除成功！*****\n");
                Console.WriteLine("→ 1 增加宿舍\n");
                Console.WriteLine("→ 2 返回宿管主菜单\n");
                Console.WriteLine("请选择操作：");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)//增加宿舍
                {
                    addHouse(m);
                }
                else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                {
                    managerHouse(m);

                }
                else
                {
                    Console.WriteLine("\n*****操作有误！*****\n");
                }
            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
               
            }
        }
        public static void changeHouse(Manager man)//修改宿舍信息
        {
            Manager m = man;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆修改宿舍◆◆◆◆◆\n");
            Console.WriteLine("→ 1 向宿舍中添加成员\n");
            Console.WriteLine("→ 2 从宿舍中移除成员\n");
            ConsoleKeyInfo key2 = Console.ReadKey();
            if (key2.Key == ConsoleKey.D1)//向宿舍中添加成员
            {
                Console.WriteLine("\n请输入寝室号：");
                string house_id = Console.ReadLine();
                Console.WriteLine("请输入要增加的学生姓名：");
                string stu_name = Console.ReadLine();
                Hashtable hs = (Hashtable)GetList.getHouseTable();
                ArrayList list = (ArrayList)GetList.getStudentList();
                Student s = null;
                if (hs != null && hs.Contains(house_id))//判断输入的寝室号是否存在
                {
                    int flag = 0;
                    for (int i = 0; list != null && i < list.Count; i++)//判断该学生是否注册
                    {
                        Student n = (Student)list[i];
                        if (n.getName().Equals(stu_name))
                        {
                            flag = 1;
                            s = n;//赋值给当前学生
                        }
                    }
                    if (flag == 1)//该学生已经注册
                    {
                        bool isExist = false;//判断该学生是否存在其他宿舍
                        int flag1 = 0;
                        if (hs != null)
                        {
                            foreach (DictionaryEntry i in hs)
                            {
                                if (flag1 == 1) break;
                                ArrayList ls = (ArrayList)i.Value;
                                for (int j = 0; j < ls.Count; j++)
                                {
                                    Student ss = (Student)ls[j];
                                    if (ss.getName().Equals(s.getName()))
                                    {
                                        flag1 = 1;
                                        isExist = true;
                                    }
                                }
                            }
                        }
                        if (isExist)//该学生存在其他宿舍
                        {
                            string exist_House_Id = "";
                            int flag2 = 0;
                            foreach (DictionaryEntry i in hs)//查询出该学生存在于哪个宿舍
                            {
                                if (flag2 == 1) break;
                                ArrayList ls = (ArrayList)i.Value;//得到hashtable的arraylist集合
                                for (int j = 0; j < ls.Count; j++)
                                {
                                    Student ss = (Student)ls[j];
                                    if (ss.getName().Equals(s.getName()))
                                    {
                                        exist_House_Id = (string)i.Key;
                                        flag2 = 1;
                                    }
                                }
                            }
                            Console.WriteLine("\n*****该学生已在" + exist_House_Id + "宿舍,添加成员失败！*****\n");
                            Console.WriteLine("→ 1 重新修改宿舍\n");
                            Console.WriteLine("→ 2 返回宿管主菜单\n");
                            Console.WriteLine("请选择操作：");
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.D1)//重新修改宿舍
                            {
                                changeHouse(m);
                            }
                            else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                            {
                                managerHouse(m);

                            }
                            else
                            {
                                Console.WriteLine("\n*****操作有误！*****\n");
                            }
                        }
                        else//该学生不存在其他宿舍
                        {
                            ArrayList ls = new ArrayList();
                            if (hs != null)
                            {
                                int flag3 = 0;
                                foreach (DictionaryEntry i in hs)//根据宿舍号查出arraylist集合
                                {
                                    if (flag3 == 1) break;
                                    string house_id1 = (string)i.Key;
                                    if (house_id1.Equals(house_id))
                                    {
                                        flag3 = 1;
                                        ArrayList lss = (ArrayList)i.Value;
                                        ls = lss;
                                    }
                                }
                            }
                            ls.Add(s);//将该同学增加到集合中
                            if (ls.Count > 6)//宿舍中不能超过6个人
                            {
                                Console.WriteLine("\n*****该宿舍已满6人，添加成员失败！*****\n");
                                Console.WriteLine("→ 1 重新修改宿舍\n");
                                Console.WriteLine("→ 2 返回宿管主菜单\n");
                                Console.WriteLine("请选择操作：");
                                ConsoleKeyInfo key = Console.ReadKey();
                                if (key.Key == ConsoleKey.D1)//重新修改宿舍
                                {
                                    changeHouse(m);
                                }
                                else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                                {
                                    managerHouse(m);

                                }
                                else
                                {
                                    Console.WriteLine("\n*****操作有误！*****\n");
                                }
                            }
                            hs.Remove(house_id);//hastable中key值不能重复 先将该宿舍删除 再重新增加该宿舍
                            SetList.setHouseTable(hs);//保存序列化更改
                            SetList.setHouseTable(house_id, ls);//将宿舍信息序列化 
                            Console.WriteLine("\n*****宿舍成员添加成功！*****\n");
                            Console.WriteLine("→ 1 继续修改宿舍\n");
                            Console.WriteLine("→ 2 返回宿管主菜单\n");
                            Console.WriteLine("请选择操作：");
                            ConsoleKeyInfo key1 = Console.ReadKey();
                            if (key1.Key == ConsoleKey.D1)//继续修改宿舍
                            {
                                changeHouse(m);
                            }
                            else if (key1.Key == ConsoleKey.D2)//返回宿管主菜单
                            {
                                managerHouse(m);

                            }
                            else
                            {
                                Console.WriteLine("\n*****操作有误！*****\n");
                            }
                        }
                    }
                    else//该学生还未注册
                    {
                        Console.WriteLine("\n*****该学生还未注册,添加成员失败！*****\n");
                        Console.WriteLine("→ 1 重新修改宿舍\n");
                        Console.WriteLine("→ 2 返回宿管主菜单\n");
                        Console.WriteLine("请选择操作：");
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.D1)//重新修改宿舍
                        {
                            changeHouse(m);
                        }
                        else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                        {
                            managerHouse(m);

                        }
                        else
                        {
                            Console.WriteLine("\n*****操作有误！*****\n");
                        };
                    }
                }
                else
                {
                    Console.WriteLine("\n*****你输入的寝室号不存在,添加成员失败！*****\n");
                    Console.WriteLine("→ 1 重新修改宿舍\n");
                    Console.WriteLine("→ 2 返回宿管主菜单\n");
                    Console.WriteLine("请选择操作：");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)//重新修改宿舍
                    {
                        changeHouse(m);
                    }
                    else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                    {
                        managerHouse(m);

                    }
                    else
                    {
                        Console.WriteLine("\n*****操作有误！*****\n");
                    }
                }
            }
            else if (key2.Key == ConsoleKey.D2)//从宿舍中移除成员
            {

                Console.WriteLine("\n请输入寝室号：");
                string house_id = Console.ReadLine();
                string house_id1 = "";
                Console.WriteLine("请输入要移除的学生姓名：");
                string stu_name = Console.ReadLine();
                Hashtable hs = (Hashtable)GetList.getHouseTable();
                ArrayList list = (ArrayList)GetList.getStudentList();
                Student s = null;
                if (hs != null && hs.Contains(house_id))//判断输入的寝室号是否存在
                {
                    int flag = 0;
                    for (int i = 0; list != null && i < list.Count; i++)//判断该学生是否注册
                    {
                        Student n = (Student)list[i];
                        if (n.getName().Equals(stu_name))
                        {
                            flag = 1;
                            s = n;//赋值给当前学生
                        }
                    }
                    if (flag == 1)//该学生已经注册
                    {
                        bool isExist = false;//判断该学生是否存在该宿舍
                        int flag1 = 0;
                        if (hs != null)
                        {
                            foreach (DictionaryEntry i in hs)
                            {
                                if (flag1 == 1) break;
                                ArrayList ls = (ArrayList)i.Value;
                                for (int j = 0; j < ls.Count; j++)
                                {
                                    Student ss = (Student)ls[j];
                                    if (ss.getName().Equals(s.getName()))
                                    {
                                        house_id1 = (string)i.Key;
                                        flag1 = 1;
                                        isExist = true;
                                    }
                                }
                            }
                        }
                        if (isExist)//该学生有宿舍
                        {
                            if (house_id.Equals(house_id1))//判断该学生所在宿舍是否为输入的宿舍
                            {
                                ArrayList ls = new ArrayList();
                                if (hs != null)
                                {
                                    int flag2 = 0;
                                    foreach (DictionaryEntry i in hs)//根据宿舍号查出arraylist集合
                                    {
                                        if (flag2 == 1) break;
                                        string house_id2 = (string)i.Key;
                                        if (house_id2.Equals(house_id))
                                        {
                                            flag2 = 1;
                                            ls = (ArrayList)i.Value;
                                        }
                                    }
                                }
                                hs.Remove(house_id);//hastable中key值不能重复 先将该宿舍删除 再重新增加该宿舍
                                SetList.setHouseTable(hs);//保存序列化更改
                                ls.Remove(s);//将该同学从集合中移除
                                SetList.setHouseTable(house_id, ls);//将宿舍信息序列化 
                                //SetList.setHouseTable(hs);
                                Console.WriteLine("\n*****宿舍成员移除成功！*****\n");
                                Console.WriteLine("→ 1 重新修改宿舍\n");
                                Console.WriteLine("→ 2 返回宿管主菜单\n");
                                Console.WriteLine("请选择操作：");
                                ConsoleKeyInfo key = Console.ReadKey();
                                if (key.Key == ConsoleKey.D1)//重新修改宿舍
                                {
                                    changeHouse(m);
                                }
                                else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                                {
                                    managerHouse(m);

                                }
                                else
                                {
                                    Console.WriteLine("\n*****操作有误！*****\n");
                                }
                            }
                            else//该学生在其他宿舍
                            {
                                string exist_House_Id = "";
                                int flag2 = 0;
                                foreach (DictionaryEntry i in hs)//查询出该学生存在于哪个宿舍
                                {
                                    if (flag2 == 1) break;
                                    ArrayList ls = (ArrayList)i.Value;//得到hashtable的arraylist集合
                                    for (int j = 0; j < ls.Count; j++)
                                    {
                                        Student ss = (Student)ls[j];
                                        if (ss.getName().Equals(s.getName()))
                                        {
                                            exist_House_Id = (string)i.Key;
                                            flag2 = 1;
                                        }
                                    }
                                }
                                Console.WriteLine("\n*****该学生不在该宿舍中，他在" + exist_House_Id + "宿舍,移除成员失败！*****\n");
                                Console.WriteLine("→ 1 重新修改宿舍\n");
                                Console.WriteLine("→ 2 返回宿管主菜单\n");
                                Console.WriteLine("请选择操作：");
                                ConsoleKeyInfo key = Console.ReadKey();
                                if (key.Key == ConsoleKey.D1)//重新修改宿舍
                                {
                                    changeHouse(m);
                                }
                                else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                                {
                                    managerHouse(m);

                                }
                                else
                                {
                                    Console.WriteLine("\n*****操作有误！*****\n");
                                }
                            }
                        }
                        else//该学生还没有宿舍
                        {
                            Console.WriteLine("\n*****该学生还没有宿舍,移除成员失败！*****\n");
                            Console.WriteLine("→ 1 重新修改宿舍\n");
                            Console.WriteLine("→ 2 返回宿管主菜单\n");
                            Console.WriteLine("请选择操作：");
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.Key == ConsoleKey.D1)//重新修改宿舍
                            {
                                changeHouse(m);
                            }
                            else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                            {
                                managerHouse(m);

                            }
                            else
                            {
                                Console.WriteLine("\n*****操作有误！*****\n");
                            }
                        }
                    }
                    else//该学生还未注册
                    {
                        Console.WriteLine("\n*****该学生还未注册,移除成员失败！*****\n");
                        Console.WriteLine("→ 1 重新修改宿舍\n");
                        Console.WriteLine("→ 2 返回宿管主菜单\n");
                        Console.WriteLine("请选择操作：");
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.D1)//重新修改宿舍
                        {
                            changeHouse(m);
                        }
                        else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                        {
                            managerHouse(m);

                        }
                        else
                        {
                            Console.WriteLine("\n*****操作有误！*****\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n*****你输入的寝室号不存在,移除成员失败！*****\n");
                    Console.WriteLine("→ 1 重新修改宿舍\n");
                    Console.WriteLine("→ 2 返回宿管主菜单\n");
                    Console.WriteLine("请选择操作：");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)//重新修改宿舍
                    {
                        changeHouse(m);
                    }
                    else if (key.Key == ConsoleKey.D2)//返回宿管主菜单
                    {
                        managerHouse(m);

                    }
                    else
                    {
                        Console.WriteLine("\n*****操作有误！*****\n");
                    }
                }

            }
            else
            {
                Console.WriteLine("*****操作有误！*****");
            }
        }
        public static void selectHouse(Manager man)//查询所有宿舍信息
        {
            Manager m = man;
            Console.Clear();
            Console.WriteLine("◆◆◆◆◆所有宿舍信息如下：◆◆◆◆◆");
            Hashtable hs = (Hashtable)GetList.getHouseTable();
            if (hs != null)
            {
                foreach (DictionaryEntry i in hs)
                {
                    ArrayList list = (ArrayList)i.Value; //得到hashtable的arraylist集合
                    Console.Write("\n宿舍号:" + i.Key);
                    Console.Write("  宿舍成员：");
                    for (int j = 0; j < list.Count; j++)
                    {
                        Student ss = (Student)list[j];
                        {
                            Console.Write(ss.getName() + "  ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n→ 1 返回宿管主菜单\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)//重新修改宿舍
            {
                managerHouse(m);
            }
            else
            {
                Console.WriteLine("\n*****操作有误！*****\n");
            }
        }
    }
}
