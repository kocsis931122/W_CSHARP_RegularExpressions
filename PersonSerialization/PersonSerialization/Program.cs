using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PersonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pityu = new Person("Pista", new DateTime(1966, 05, 07));
            Person jozsika = new Person("József", new DateTime(1954, 11, 22));
            Person ferike = new Person("Ferenc", new DateTime(1980, 03, 26));

            Console.WriteLine(pityu);
            Console.WriteLine(jozsika);
            Console.WriteLine(ferike);

            Serialize(pityu);
            Serialize(jozsika);
            Serialize(ferike);

            Person deserializePerson = Deserialize();
            Console.WriteLine("Deserialized person: ");
            Console.WriteLine(deserializePerson);

        }
        private static void Serialize(Person sp)
        {
            //Create file to save the data to
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            //Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            //Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, sp);

            //Close the file
            fs.Close();
        }
        private static Person Deserialize()
        {
            Person dsp = new Person();
            // Open file to read the data from 
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization 
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to deserialize the data
            // from the file 
            dsp = (Person)bf.Deserialize(fs);

            // Close the file 
            fs.Close();

            return dsp;
        }
    }
}
