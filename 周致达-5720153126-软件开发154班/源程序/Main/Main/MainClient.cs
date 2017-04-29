using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 周致达
 * 软件开发154班
 * 5720153126
 */
namespace Main
{
    class MainClient//主菜单类
    {
        static void Main(string[] args)
        {
            Console.WriteLine("★★★★★★★江西理工大学宿舍管理系统★★★★★★★\n");
            Console.WriteLine("→ 1 宿管端\n");
            Console.WriteLine("→ 2 学生端\n");
            Console.WriteLine("→ 3 退出系统\n");
            Console.WriteLine("请选择操作：");
            ConsoleKeyInfo key=Console.ReadKey();
            if (key.Key== ConsoleKey.D1)//跳转至宿管端菜单
            {
                    ManagerDao.managerMenu();
            }
            else if (key.Key == ConsoleKey.D2)//跳转至学生端菜单
            {
                    StudentDao.studentMenu();
            }
            else if (key.Key == ConsoleKey.D3)//退出系统
            {
                Console.WriteLine("\n*****已退出系统！*****\n");
                return;
            }
            else
            {
                Console.WriteLine("\n操作有误！\n");
            }

        }
    }
}
