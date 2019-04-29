using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace WASiigo.Utils
{
    public class Util
    {
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static T fromJson<T>(string json)
        {
            var bytes = Encoding.Unicode.GetBytes(json);

            using (MemoryStream mst = new MemoryStream(bytes))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(mst);
            }
        }

        public static string toJson(object instance)
        {
            using (MemoryStream mst = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                serializer.WriteObject(mst, instance);
                mst.Position = 0;
                using (StreamReader r = new StreamReader(mst))
                {
                    return r.ReadToEnd();
                }
            }
        }
    }
}