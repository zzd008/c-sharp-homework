using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    [Serializable]//对象序列化
    class Manager//宿管类
    {
        private string manager_name;
        private string manager_password;
        public Manager(string name,string password)//构造方法
        {
            this.manager_name = name;
            this.manager_password = password;
        }
        public void showInfo()//显示信息
        {
            Console.WriteLine("注册宿管名字："+this.manager_name+"  密码："+this.manager_password);
        }
        public string getName()
        {
            return this.manager_name;
        }
        public string getPassword()
        {
            return this.manager_password;
        }
    }
}
