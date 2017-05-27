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

        static public bool AddPoem(Poem poem)
        {
            int PoemKey = Poems.Count;
            Poems.Add(poem);
            XmlSerializer serializer = new XmlSerializer(typeof(Poem));
            string PoemFilePath = "Poems\\$NAME$.xml";
            PoemFilePath = PoemFilePath.Replace("$NAME$", Poems.IndexOf(poem).ToString());
            File.Create("PoemFilePath");
            try
            {
                TextWriter writer = new StreamWriter(PoemFilePath);
                serializer.Serialize(writer, poem);
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public bool AddAuthor(Author author)
        {
            int AuthorKey = Authors.Count;
            Authors.Add(author);
            XmlSerializer serializer = new XmlSerializer(typeof(Author));
            string AuthorFilePath = "Authors\\$NAME$.xml";
            AuthorFilePath = AuthorFilePath.Replace("$NAME$", Authors.IndexOf(author).ToString());
            File.Create("AuthorFilePath");
            try
            {
                TextWriter writer = new StreamWriter(AuthorFilePath);
                serializer.Serialize(writer, author);
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public bool DeletePoem(Poem poem)
        {
            if (!Poems.Contains(poem))
            {
                return true;
            }
            else
            {
                string PoemFilePath = "Poems\\$NAME$.xml";
                PoemFilePath = PoemFilePath.Replace("$NAME$", Poems.IndexOf(poem).ToString());
                File.Delete(PoemFilePath);
                Poems.Remove(poem);
                if (!File.Exists(PoemFilePath))
                {
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteAuthor(Author author)
        {
            if (!Authors.Contains(author))
            {
                return true;
            }
            else
            {
                string AuthorFilePath = "Authors\\$NAME$.xml";
                AuthorFilePath = AuthorFilePath.Replace("$NAME$", Authors.IndexOf(author).ToString());
                File.Delete(AuthorFilePath);
                Authors.Remove(author);
                if (!File.Exists(AuthorFilePath))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
