using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksAndAuthors
{
    public class AuthorSerializer : IAuthorSerializer
    {
        private XmlSerializer mySerializer;

        public AuthorSerializer() 
        {
            mySerializer = new XmlSerializer(typeof(Author));
        }

        public void Serializing(Author author, string fileName)
        {
            using (StreamWriter myWriter = new StreamWriter(fileName))
            {
                mySerializer.Serialize(myWriter, author);
            }
        }

        public Author Deserializing(string filePath)
        {
            using (FileStream myFileStream = new FileStream(filePath, FileMode.Open))
            {
                Author author = (Author)mySerializer.Deserialize(myFileStream);
                return author;
            }
        }
    }
}
