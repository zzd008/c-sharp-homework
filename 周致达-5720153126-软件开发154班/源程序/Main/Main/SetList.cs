using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Main
{
    class SetList//序列化类
    {
        public static void setList(Manager m)//序列化宿管对象
        {
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\宿管信息.txt";
            ArrayList list = (ArrayList)GetList.getManagerList();
            if(list==null)//判断集合是否为空
            {
                list = new ArrayList();
            }
            list.Add(m);
            FileStream fs = new FileStream(filepath,FileMode.Create);//操作流
            BinaryFormatter bf = new BinaryFormatter();//序列化操作对
            try
            {
                bf.Serialize(fs, list);
                //Console.WriteLine("对象序列化成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void setList(Student s)//序列化学生对象
        {
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\学生信息.txt";
            ArrayList list = (ArrayList)GetList.getStudentList();
            if (list == null)
            {
                list = new ArrayList();
            }
            list.Add(s);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void setHouseTable(string house_id,ArrayList list)//序列化宿舍对象
        {
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\宿舍信息.txt";
            Hashtable hs = (Hashtable)GetList.getHouseTable();
            if (hs == null)
            {
                hs = new Hashtable();
            }
            hs.Add(house_id, list);//hashtable中存放house_id和arraylist arraylist中存放学生对象
            FileStream fs = new FileStream(filepath,FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, hs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void setHouseTable(Hashtable h)//更新宿舍对象hashtable
        {
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\宿舍信息.txt";
            Hashtable hs = h;
            if (hs == null)
            {
                hs = new Hashtable();
            }
            FileStream fs = new FileStream(filepath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, hs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void setStudentList(ArrayList l)//更新学生对象集合
        {
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\学生信息.txt";
            ArrayList list=l;
            if (list == null)
            {
                list = new ArrayList();
            }
            FileStream fs = new FileStream(filepath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
