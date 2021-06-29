using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Control
{
    public class Data
    {
        public static int questionNumber { get; set; }
        public const string pathToSaveTest = @"C:\Users\odarf\Desktop\test.xml";
        public static List<Questions> ListOfQuestions = new List<Questions>();
        public static string pathToOpenTest { get; set; }
    }

    [Serializable]
    public class Questions
    {
        public string question { get; set; }
        public string[] answers = new string[4];
        public  string path {get; set;}
        public int rightAnswerNumber;
    }


    public class XML
    {
        public static void Serialazable (List<Questions> ListOfQuestions)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Questions>));
            using (FileStream fs = new FileStream(Data.pathToSaveTest, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                formatter.Serialize(fs, ListOfQuestions);
                fs.Close();
            }
        }

        public static void Deserializable(List<Questions> ListOfQuestions, string pathToTest)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Questions>));
            using (FileStream fs = new FileStream(pathToTest, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if ((int)fs.Length != 0)
                    ListOfQuestions = (List<Questions>)formatter.Deserialize(fs);
                else
                    ListOfQuestions = new List<Questions>(0);
                fs.Close();
            }
        }
        public static void Deserializable(List<Questions> ListOfQuestions)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Questions>));
            using (FileStream fs = new FileStream(Data.pathToSaveTest, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if ((int)fs.Length != 0)
                    ListOfQuestions = (List<Questions>)formatter.Deserialize(fs);
                else
                    ListOfQuestions = new List<Questions>(1);
                fs.Close();
            }
        }
    }
}
