using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Git!");

            IMember firstMember = new FirstMember();
            firstMember.introduction();

            IMember secondMember = new SecondMember();
            secondMember.introduction();

            IMember thirdMember = new ThirdMember();
            thirdMember.introduction();

            IMember fourthMember = new FourthMember();
            fourthMember.introduction();
        }
    }
}
