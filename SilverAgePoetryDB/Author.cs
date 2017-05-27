using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverAgePoetryDB
{
    class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string BirthPlace { get; set; }
        public string Biography { get; set; }
        public Dictionary<int, Poem> Poems { get; set; }
    }
}
