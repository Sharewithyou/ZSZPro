using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DAL;

namespace MySimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {


            //foreach (System.Reflection.PropertyInfo p in typeof(ZSZ.Model.ZSZProjContext).GetProperties())
            //{
            //    if (p.CanWrite)
            //    {
            //        Console.WriteLine(p.Name.Replace("T_","").Replace("s",""));
            //    }               
            //}
            List<string> list = new List<string>();
            foreach (System.Reflection.PropertyInfo p in typeof(ZSZ.DAL.ZSZProjContext).GetProperties())
            {
                if (p.CanWrite)
                {
                    //var name = p.Name.Replace("T_","I");
                    list.Add(p.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
