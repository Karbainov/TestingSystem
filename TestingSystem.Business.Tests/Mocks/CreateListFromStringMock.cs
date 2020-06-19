using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests
{
    public class CreateListFromStringMock
    {
        public List<string> GetExpected(int num)
        {
            List<string> result;
            switch (num)
            {
                case 1: 
                    result = new List<string>() { "zzz", "aaa" };
                    return result;
                    
                case 2:
                    result = new List<string>() { "параметры", "swith", "уравнения", "C#" };
                    return result;
                    
                case 3:
                    result = new List<string>() { "" } ;
                    return result;
                    
            }
            return null;
        }
        public string GetActual(int num)
        {
            switch(num)
            {
                case 1:
                    return " zzz , aaa ";
                    
                case 2:
                    return "параметры,swith ,     уравнения   , C# ";
                    
                case 3:
                    return "";
                    
            }

            return null;
        }
    }
}
