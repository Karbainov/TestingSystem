using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Tests
{
    public class FindTagsIDMock
    {
        public List<int> GetExpected(int num)
        {
            List<int> result;
            switch (num)
            {
                case 1:
                    result = new List<int>() { 1, 3, 7 };
                    return result;
                case 2:
                    result = new List<int>() { 1 };
                    return result;
                case 3:
                    result = new List<int>();
                    return result;
            }
            return null;
        }
        public List<TagDTO> GetTagDTOs(int num)
        {
            List<TagDTO> tags;
            switch (num)
            {
                case 1:
                    tags = new List<TagDTO>()
                    {
                        new TagDTO(1,"q"),
                        new TagDTO(2,"w"),
                        new TagDTO(3,"e"),
                        new TagDTO(4,"r"),
                        new TagDTO(5,"t"),
                        new TagDTO(6,"y"),
                        new TagDTO(7,"u")
                    };
                    return tags;
                case 2:
                    tags = new List<TagDTO>() { new TagDTO(1, "") };
                    return tags;
                case 3:
                    tags = new List<TagDTO>();
                    return tags;
            }
            return null;
        }
        public List<string> GetTags(int num)
        {
            List<string> tags = new List<string>();
            switch (num)
            {
                case 1:
                    tags = new List<string>() { "q", "e", "u" };
                    break;
                case 2:
                   tags = new List<string>() { "" };
                    break;
                case 3:
                    tags = new List<string>();
                    break;
            }
            return tags;
        }
    }
}
