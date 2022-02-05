using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsCodeSamples.Models;

namespace WindowsFormsCodeSamples.Classes
{
    public class FileOperations
    {
        public static string _fileName = "people.txt";
        /// <summary>
        /// Write people back to same file as read from
        /// </summary>
        /// <param name="peopleList">valid list of <seealso cref="Person"/></param>
        public static void Write(List<Person> peopleList)
        {

            File.WriteAllLines(_fileName, peopleList
                .Select(person => person.Lines)
                .ToArray());

        }

        /// <summary>
        /// Assumes file exists and there are three line per person.
        ///
        /// chunks array uses index in the select although never used
        /// Index could be used as a primary key.
        /// </summary>
        /// <returns>List of <see cref="Person"/> and <seealso cref="Exception"/></returns>
        public static (List<Person>, Exception) Read()
        {

            const int chunkSize = 3;

            try
            {
                var contents = File.ReadAllLines(_fileName);

                string[][] chunks = contents
                    .Select((line, index) => new { Line = line, Index = index })
                    .GroupBy(anonymous => anonymous.Index / chunkSize)
                    .Select(grp => grp.Select(anonymous => anonymous.Line).ToArray())
                    .ToArray();

                var result = chunks.Select(item => new Person()
                {
                    FirstName = item[0],
                    LastName = item[1],
                    Phone = item[2]
                }).ToList();

                return (result, null);

            }
            catch (Exception exception)
            {
                return (null, exception);
            }
        }
    }
}
