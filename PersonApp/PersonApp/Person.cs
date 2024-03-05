using System.Xml.Serialization;

namespace PersonApp
{
    public delegate void AgeChangingDelegate(int oldAge, int newAge);

    [XmlRoot("Személy")]
    public class Person
    {
        public event AgeChangingDelegate AgeChanging;

        private int age;

        [XmlAttribute("Kor")]
        public int Age
        {
            get { return age; }
            set
            {
                if (age == value)
                    return;
                if (value < 0)
                    throw new ArgumentException("Érvénytelen életkor!");
                AgeChanging?.Invoke(age, value);
                age = value;
            }
        }

        [XmlIgnore]
        public required string Name { get; init; }

        public int AgeInDogYear => Age * 7;

        public int GetAgeInDogYear() => Age * 7;

        public void DisplayName() => Console.WriteLine(ToString());
    }
}