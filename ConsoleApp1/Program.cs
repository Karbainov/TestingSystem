using System;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ForDeletedManager manager = new ForDeletedManager();
            foreach(var a in manager.GetDeletedWithTests())
            {
                Console.WriteLine(a.ID);
                Console.WriteLine(a.DurationTime);
                Console.WriteLine(a.Name);
                Console.WriteLine(a.QuestionNumber);
                Console.WriteLine(a.SuccessScore);
                foreach(var d in a.Questions)
                {
                    Console.WriteLine(d.Value);

                }
                foreach(var c in a.Tags)
                {
                    Console.WriteLine(c.Name);
                }

            }
            //Console.WriteLine(manager.GetDeletedWithTests());
        }
    }
}
