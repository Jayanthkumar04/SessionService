using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient2.ServiceReference1;

namespace ConsoleClient2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Service1Client service = new Service1Client("NetTcpBinding_IService1");

            for(int i=0;i<3;i++)
            {
                Console.WriteLine("entr record " +( i+1));

                service.save(new Course() { Id=int.Parse(Console.ReadLine()),Name=Console.ReadLine() });
            }

            GetCourses(service);

            Console.ReadKey();
            
        }

        public static void GetCourses(Service1Client service)
        {

            Console.WriteLine();

            foreach(var item in service.getCourses())
            {
                Console.WriteLine("COURSE Id :{0} CourseName:{1}", item.Id, item.Name);
            }
        }
    }
}
