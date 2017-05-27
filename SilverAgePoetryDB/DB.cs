using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SilverAgePoetryDB
{
    static class DB
    {
        static public List<Poem> Poems { get; set; }
        static public List<Author> Authors { get; set; }

        static public bool SynchronizePoems()
        {
            if (File.Exists("poems.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Poem));
                TextWriter writer = new StreamWriter("poems.xml");
                foreach (Poem poem in Poems)
                {
                    serializer.Serialize(writer, poem);
                }
                writer.Close();
            }
            else
            {
                File.Create("poems.xml");
            }
            return true;
        }
    }
}
