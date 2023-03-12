using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperChallenge.Models.Dtos.OutputDtos
{
    public class QuotableOutputDto
    {
        public string _id { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public string[] tags { get; set; }
        public string authorSlug { get; set; }
        public int length { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime dateModified { get; set; }
    }
    public class QuotableActualOutputDto
    {
        public string category { get; set; }
        public List<QuotableOutputDto> quotables { get; set; }

    }
}
