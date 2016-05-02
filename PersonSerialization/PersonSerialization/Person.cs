using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonSerialization
{
    [Serializable]
    class Person : IDeserializationCallback, ISerializable
    {
        [NonSerialized]
        private int age;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Person()
        {
        }
        public Person(string Name, DateTime birthDate)
        {
            this.Name = Name;
            this.birthDate = birthDate;
            CalculateAge();
        }
        public enum Genders : int { Male, Female };
        public Genders gender;

        public override string ToString()
        {
            return (String.Format("name: {0}, birth date: {1} age: {2}", this.name, this.birthDate, this.age));
        }
        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            BirthDate = info.GetDateTime("DOB");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("DOB", BirthDate);
            Name = info.GetString("Name");
            BirthDate = info.GetDateTime("DOB");
        }

        public void OnDeserialization(object sender)
        {
            CalculateAge();
        }
        private void CalculateAge()
        {
            this.age = DateTime.Now.Year - BirthDate.Year;
        }
    }
}
