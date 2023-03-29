using PB03.Pages.Forms;
using System.Text.Json;

namespace PB03.App.Session
{
    public static class SessionExtensions
    {
        public static void AddItem<T>(this ISession session, string key, T item)
        {
            var list = session.AsList<T>(key);

            if (list == null) list = new List<T>();

            list.Add(item);

            session.SetString(key, JsonSerializer.Serialize(list));
        }

        public static List<T> AsList<T>(this ISession session, string key)
        {
            var json = session.GetString(key);

            if(json == null)
            {
                session.SetString(key, JsonSerializer.Serialize(new List<T>()));
            }

            return JsonSerializer.Deserialize<List<T>>(session.GetString(key)!)!;
        }
    }
}
