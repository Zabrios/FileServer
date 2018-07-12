using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using FileServer.Common.Model;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class XmlFileManager : FileManager
    {
        public override string FileExtension { get; set; }
        public override string FilePath { get; set; }

        public XmlFileManager(int filePathType)
        {
            FileExtension = ConfigurationManager.AppSettings.Get("xmlFile");
            FilePath = FilePathManager.PathSelector(filePathType) + FileExtension;
        }

        public override void CreateFile()
        {
            if (!FileExists())
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode decNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                    doc.AppendChild(decNode);
                    XmlElement root = doc.CreateElement("Alumnos");
                    doc.AppendChild(root);
                    XmlComment comment = doc.CreateComment("Alumno XML File");
                    root.AppendChild(comment);
                    //doc.LoadXml("<Alumnos></Alumnos>");
                    //XElement root = new XElement("Alumnos");
                    doc.Save(FilePath);
                    //using (XmlWriter writer = XmlWriter.Create(FilePath)) { }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public override bool FileExists()
        {
            return File.Exists(FilePath);
        }

        public override string RetrieveData()
        {
            try
            {
                XDocument doc = XDocument.Load(FilePath);
                XElement root = doc.Root;
                XElement lastNode = (XElement)root.LastNode;
                //Console.WriteLine(lastNode.ToString());
                if(lastNode == null)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine(lastNode.ToString());
                    return lastNode.ToString();
                }
                //XmlSerializer serializer = new XmlSerializer(typeof(Alumno));
                //FileStream fs = new FileStream(FilePath, FileMode.Open);
                //XmlReader reader = XmlReader.Create(fs);
                //Alumno al;
                //al = (Alumno)serializer.Deserialize(reader);
                //fs.Close();
                //return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override void WriteToFile(string fileData)
        {
            try
            {
                string[] items = fileData.Split(',');
                var alumno = new Alumno(items[0], items[1], items[2], items[3]);

                XDocument doc = XDocument.Load(FilePath);
                XElement root = doc.Element("Alumnos");
                doc.Root.Add(new XElement("Alumno",
                    new XElement("ID", alumno.Id),
                    new XElement("Nombre", alumno.Nombre),
                    new XElement("Apellidos", alumno.Apellidos),
                    new XElement("DNI", alumno.DNI)));
                doc.Save(FilePath);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override Alumno ProcessAlumnoData(Alumno alumno)
        {
            try
            {
                CreateFile();
                WriteToFile(alumno.ToString());
                var retrieveResult = RetrieveData();
                XDocument doc = XDocument.Parse(retrieveResult);
                var alumnos = new List<Alumno>();
                var al = (from element in doc.Descendants("Alumno")
                           select new Alumno()
                           {
                            Id = element.Element("ID").Value,
                            Nombre = element.Element("Nombre").Value,
                            Apellidos = element.Element("Apellidos").Value,
                            DNI = element.Element("DNI").Value
                           }).ToList().Last();

                Alumno alumnoRetorno = al;
                return alumnoRetorno; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
