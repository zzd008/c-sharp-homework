using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    [Serializable]//对象序列化
    class Student//学生类
    {
        private string stu_name;
        private string stu_password;
        private string stu_number;
        private string stu_class;
        public Student(string name, string password,string number,string Class)//构造方法
        {
            this.stu_name = name;
            this.stu_password = password;
            this.stu_number=number;
            this.stu_class=Class;    
        }
        public void showInfo()//显示信息
        {
            Console.WriteLine("注册学生名字：" + this.stu_name + "  密码：" + this.stu_password
                +" 学号："+this.stu_number+" 班级:"+this.stu_class);
        }
        public string getName()
        {
            return this.stu_name;
        }
        public string getPassword()
        {
            return this.stu_password;
        }
        public string getNumber()
        {
            return this.stu_number;
        }
        public string getClass()
        {
            return this.stu_class;
        }
        public void setPassword(string ps)//修改密码
        {
            this.stu_password = ps;
        }
    }
}
