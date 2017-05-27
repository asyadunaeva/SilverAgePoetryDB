using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverAgePoetryDB
{
    class Poem
    {
        public string Name { get; set; }
        public Author Author { get; set; }
        public DateTime WritingStartDate { get; set; }
        public DateTime WritingEndDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Text { get; set; }
    }
}
