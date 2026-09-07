using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_demo
{
    class FirstMember: IMember
    {
        public void introduction()
        {
            Console.WriteLine("各位兄弟姐妹们好，我是第一位成员，下面做一下自我介绍：");
        }
    }
}
