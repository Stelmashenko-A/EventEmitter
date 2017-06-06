using System;
using System.Collections.Generic;
using System.Linq;
using DataMiner.Services.Models;

namespace DataMiner.Services
{
    public class SQLInsertBuilder
    {
        public Random Random = new Random();
        protected const string PatternCategory = @"INSERT INTO Category
VALUES ('{0}', '{1}', '{2}', '{3}');
";
        protected const string PatternUser = @"INSERT INTO UserAccounts
VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
";
        protected const string PatternEvent = @"INSERT INTO Events
VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
";

        protected const string PatternRegistration = @"INSERT INTO Registrations
VALUES ('{0}', '{1}', '{2}', '{3}');
";

        public string BuildCategory(EventCategory cat)
        {
            return BuildCategory(cat.Name, cat.ShortName, "");
        }

        protected string BuildCategory(string name, string shortName, string description)
        {
            return string.Format(PatternCategory, Guid.NewGuid().ToString().ToUpper(), name, shortName, description);
        }

        public string BuildUser(Organizer user)
        {
            return BuildUser(user.Name, user.Id);
        }

        protected string BuildUser(string name, string id)
        {
            return string.Format(PatternUser, Guid.NewGuid().ToString().ToUpper(), name, "Google", id, "description", "BAB88D89-9BEF-478B-9F46-DF8CBA5BA1D5");
        }

        public string BuildEvent(Event @event, List<string>users,Dictionary<string,string> cats)
        {
            var user = users.ElementAt(Random.Next(users.Count));
            var cat = cats[@event.Category.Name];
            return BuildEvent(@event.Name.Text, user,@event.Description.Text,cat,@event.Start.Utc);
        }

        protected string BuildEvent(string name, string userid,string text,string cat,string d)
        {
            if (text.Contains("als 70 Bands und DJ"))
            {
                int h = 0;
            }
            name = name.Replace("\'", "");
            text = text.Replace("\'", "");
            name = name.Replace("’", "");
            text = text.Replace("’", "");
            name = name.Replace("´", "");
            text = text.Replace("´", "");
            var free = Random.Next()%2 == 1;
            return string.Format(PatternEvent, Guid.NewGuid().ToString().ToUpper(),
                d,
                Random.Next(1000),
                Random.Next(100),
                free ? 0 : Random.Next(100),
                "78E0386C-2596-44BA-8939-36221DC63806",
                DateTime.Now.ToUniversalTime().Subtract(
                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    ).TotalMilliseconds.ToString().Replace(',','.'),
                userid,
                name,
                text,
                "",
                cat);
        }

                public string BuildRegistration(string @event, string user)
                {
                    bool flag = Random.Next()%3==0;
                    var type = "341eef50-f5ea-48ac-871b-3700a50edcae";
                    if (flag)
                    {
                type = "7fb9fc51-07d5-4977-9d3d-8b7cbf106c7f";
            }
            return BuildRegistration(@event,user,type);
        }

        protected string BuildRegistration(string @event, string user, string type)
        {
            return string.Format(PatternRegistration,
                Guid.NewGuid().ToString().ToUpper(),
                type,
                user,
                @event);
        }
    }
}
