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
    class GetList//反序列化类
    {
        public static ArrayList getManagerList()//宿管对象反序列化
        {
            ArrayList list = null;
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\宿管信息.txt";
            FileStream fs = null;
            try//要try catch 否则异常 因为文件不能被同时操作
            {
                if (!File.Exists(filepath))//判断文件是否存在
                {
                    fs = new FileStream(filepath, FileMode.Create);
                    return null;
                }
                else
                {
                    fs = new FileStream(filepath, FileMode.Open);//获取文件操作流
                }
                BinaryFormatter bf = new BinaryFormatter();//序列化操作对象
                list = (ArrayList)bf.Deserialize(fs);//反序列化
                //Console.WriteLine("对象反序列化成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                fs.Close();
            }
            return list;
        }
        public static ArrayList getStudentList()//学生对象反序列化
        {
            ArrayList list = null;
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\学生信息.txt";
            FileStream fs = null;
            try
            {
                if (!File.Exists(filepath))
                {
                    fs = new FileStream(filepath, FileMode.Create);
                    return null;
                }
                else
                {
                    fs = new FileStream(filepath, FileMode.Open);
                }
                BinaryFormatter bf = new BinaryFormatter();
                list = (ArrayList)bf.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return list;
        }
        public static Hashtable getHouseTable()//宿舍对象序列化
        {
            Hashtable hs = null;
            string filepath = @"C:\Users\zzd\Desktop\c#对象持久化\宿舍信息.txt";
            FileStream fs = null;
            try
            {
                if (!File.Exists(filepath))
                {
                    fs = new FileStream(filepath, FileMode.Create);
                    return null;
                }
                else
                {
                    fs = new FileStream(filepath,FileMode.Open);
                }
                BinaryFormatter bf = new BinaryFormatter();
                hs=(Hashtable)bf.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            return hs;
        }
    }
}
