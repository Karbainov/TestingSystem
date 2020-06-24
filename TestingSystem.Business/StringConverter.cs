using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystem.Business
{
    public class StringConverter
    {
        public List<string> CreateListFromString(string tags)
        {
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (tags[i] == ' ')
                    {

                        tags = tags.Remove(i, 1);
                        i--;
                    }
                }
                for (int i = 0; i < tags.Length - 1; i++)
                {
                    if (tags[i] == ',' && tags[i + 1] == ',')
                    {
                        tags = tags.Remove(i);
                    }
                }
                List<string> listOfTags = new List<string>(tags.Split(new char[] { ',' }).ToList<string>());

                return listOfTags;
            }
            return null;
        }
        public string[] CreateArrayFromString(string tags)
        {
            if (tags != null)
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (tags[i] == ' ')
                    {

                        tags = tags.Remove(i, 1);
                        i--;
                    }
                }
                for (int i = 0; i < tags.Length - 1; i++)
                {
                    if (tags[i] == ',' && tags[i + 1] == ',')
                    {
                        tags = tags.Remove(i);
                    }
                }

                string[] lot = tags.Split(new char[] { ',' }).ToArray<string>();
                return lot;
            }
            return null;
        }
    }
}
