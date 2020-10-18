using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEnums_Show
{
    // add the reference to the newly generated dll
    // use MyEnums;

    class Program
    {
        static void Main()
        {
            Assembly assembly = Assembly.LoadFrom("DynamicEnums.dll");

            //Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("EnumeratedTypes.MyEnum");
            Array values = Enum.GetValues(type);

            foreach (var val in values)
            {
                Console.WriteLine(String.Format("{0}: {1}",
                        Enum.GetName(type, val),
                        val));
            }

            Console.WriteLine("Hit enter to exit ");
            Console.ReadLine();
        } //eof Main 
    } //eof Program
}
