using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poprica
{
    public static class DataManager
    {

        /// <summary>
        /// Loads an object from a json file.
        /// </summary>
        /// <typeparam name="T">Holds the type of the returning object array.</typeparam>
        /// <param name="paths">Array of file destinations.</param>
        /// <returns>Array of objects of type T.</returns>
        public static T[] LoadJson<T>(string[] paths)
        {
            T[] array = new T[paths.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string json = File.ReadAllText(paths[i]);
                array[i] = JsonConvert.DeserializeObject<T>(json);
            }

            return array;
        }

    }
}
