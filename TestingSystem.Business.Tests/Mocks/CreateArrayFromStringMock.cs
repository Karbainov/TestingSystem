using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests.Mocks
{
    class CreateArrayFromStringMock
    {
        public string[] GetExpected(int num)
        {
            string[] result;
            switch (num)
            {
                case 1:
                    result =new string[2] { "zzz", "aaa"} ;
                    return result;

                case 2:
                    result = new string[4] { "параметры", "swith", "уравнения", "C#" };
                    return result;

                case 3:
                    result = new string[1] { "" };
                    return result;

            }
            return null;
        }
        public string GetActual(int num)
        {
            switch (num)
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
