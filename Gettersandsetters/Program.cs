using System;

namespace Gettersandsetters
{
    class Program
    {


        class Person
        {
            string name;
            string gender;
            int age;
            string idcode;

            public Person(string _name, string _gender, int _age, string _idcode)
            {
                Name = _name;
                gender = _gender;
                Age = _age;
                Idcode = _idcode;

            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Gender
            {
                get { return gender; }
                set
                {
                    if (value == "male"|| value =="female")
                    {
                        gender = value;
                    }
                    else
                    {
                        gender = "unicorn";
                    }
                }
            }

            public string Idcode
            {
                get { return idcode; }
                set
                {
                    if (value.Length== 11)
                    {
                        idcode = value;
                    }
                    else
                    {
                        idcode = " Is not correct";
                    }
                }
            }

            public int Age
            {
                get { return age; }
                set
                {
                    if (value >=0)
                    {
                        age = value;
                    }
                    else
                    {
                        age = 0;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            
            Person newPerson = new Person("John", "male", 34,"54321987600");
            Console.WriteLine($"A new person {newPerson.Name}");
            newPerson.Name = "Johanna";
            Console.WriteLine($"A new person {newPerson.Name}");
            newPerson.Gender = "Fairy";
            Console.WriteLine($"Gender: {newPerson.Gender}");
            newPerson.Idcode = "54321987603";
            Console.WriteLine($"IDcode: {newPerson.Idcode}");
            Console.WriteLine($" {newPerson.Name} age: {newPerson.Age}");
            
        }
    }
}