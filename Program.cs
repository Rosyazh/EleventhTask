using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EleventhTask
{
    class TypeInfo
    {
        public void DisplayMethods()
        {
            //List<MethodInfo> methods = typeof(InputClass).GetMethods().ToList();
            IEnumerable<MethodInfo> methods = typeof(InputClass).GetTypeInfo().DeclaredMethods;
            foreach (MethodInfo method in methods)
                Console.WriteLine(method);
        }

        public void DisplayConstructors()
        {
            List<ConstructorInfo> constructors = typeof(InputClass).GetConstructors().ToList();
            foreach (ConstructorInfo constructor in constructors)
                Console.WriteLine(constructor);
        }

        public void DisplayMembers()
        {
            //List<MemberInfo> members = typeof(InputClass).GetMembers().ToList();
            IEnumerable<MemberInfo> members = typeof(InputClass).GetTypeInfo().DeclaredMembers;
            foreach(MemberInfo member in members)
                Console.WriteLine(member);
        }

        public void DisplayFields()
        {
            List<FieldInfo> fields = typeof(InputClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field);
            }
        }

        public void DisplayValuesOfTheFields()
        {
            object instance = (InputClass)Activator.CreateInstance(typeof(InputClass));
            List<FieldInfo> fields = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }

    class InputClass
    {
        private string line;
        private int number;

        public InputClass()
        {
            line = "some string";
            number = 34;
        }

        public InputClass(string _str)
        {
            line = _str;
        }
        
        public InputClass(int _num)
        {
            number = _num;
        }
        
        public string WriteTheString()
        {
            Console.WriteLine("The output string.");
            return line;
        }

        public void SomeMethod()
        {
            Console.WriteLine("Some method.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TypeInfo m = new TypeInfo();
            Console.WriteLine("Information about InputClass");
            Console.WriteLine("\nMembers");
            m.DisplayMembers();
            Console.WriteLine("\nMethods:");
            m.DisplayMethods();
            Console.WriteLine("\nConstructors:");
            m.DisplayConstructors();   
            Console.WriteLine("\nFields:");
            m.DisplayFields();
            Console.WriteLine("\nValues of the fields:");
            m.DisplayValuesOfTheFields();
        }
    }
}
