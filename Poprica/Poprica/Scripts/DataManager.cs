using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Poprica
{
    public static class DataManager
    {

        private static JsonSerializerSettings settings;

        private static void SetJsonSettings()
        {
            settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            
            settings.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.TypeNameHandling = TypeNameHandling.Auto;

            settings.ContractResolver = new DictionaryAsArrayResolver();
        }

        public static T LoadJson<T>(string path)
        {
            SetJsonSettings();

            T data;

            string json = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        public static T LoadJsonDict<T>(string path)
        {
            SetJsonSettings();

            T data;

            string json = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<T>(json, settings);

            return data;
        }

        /// <summary>
        /// Loads an object from a json file.
        /// </summary>
        /// <typeparam name="T">Holds the type of the returning object array.</typeparam>
        /// <param name="paths">Array of file destinations.</param>
        /// <returns>Array of objects of type T.</returns>
        public static T[] LoadJsons<T>(string[] paths)
        {
            SetJsonSettings();

            T[] array = new T[paths.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string json = File.ReadAllText(paths[i]);
                array[i] = JsonConvert.DeserializeObject<T>(json);
            }

            return array;
        }

        public static void SaveJsonDict<T>(T data, string path)
        {
            SetJsonSettings();

            string json = JsonConvert.SerializeObject(data, settings);
            File.WriteAllText(path, json);
        }

        public static void SaveJson<T>(T data, string path)
        {
            SetJsonSettings();

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        public static void SaveJsons<T>(T[] data, string[] paths)
        {
            SetJsonSettings();

            for (int i = 0; i < data.Length; i++)
            {
                string json = JsonConvert.SerializeObject(data[i]);
                File.WriteAllText(paths[i], json);
            }
        }
    }

    //https://stackoverflow.com/questions/12751354/serialize-dictionary-as-array-of-key-value-pairs
    class DictionaryAsArrayResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType.GetInterfaces().Any(i => i == typeof(IDictionary<,>) ||
                (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))))
            {
                return base.CreateArrayContract(objectType);
            }

            return base.CreateContract(objectType);
        }
    }
}
