using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMiner.Services.Models;
using Raven.Client;
using Raven.Client.Document;

namespace DataMiner.Services.RavenDB
{
    public class Storage
    {
        private IDocumentStore store { get; set; }
        public Storage()
        {
            store = new DocumentStore()
            {
                Url = "http://localhost:8080/", // server URL
                DefaultDatabase = "Events"
            };
            store.Initialize();
        }
        public void Save(RootObject obj)
        {

            store.Initialize(); // initializes document store, by connecting to server and downloading various configurations

            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                session.Store(obj); // stores employee in session, assigning it to a collection `Employees`
                session.SaveChanges(); // sends all changes to server
            }

        }

        public void Save(Event obj)
        {

             // initializes document store, by connecting to server and downloading various configurations

            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                session.Store(obj); // stores employee in session, assigning it to a collection `Employees`
                session.SaveChanges(); // sends all changes to server
            }

        }

        public void Save(EventCategory obj)
        {

            // initializes document store, by connecting to server and downloading various configurations

            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                session.Store(obj); // stores employee in session, assigning it to a collection `Employees`
                session.SaveChanges(); // sends all changes to server
            }

        }

        public IEnumerable<RootObject>Get(int page)
        {
            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                return session.Query<RootObject>().OrderBy(x => x.Id).Skip(100*page).Take(100); // stores employee in session, assigning it to a collection `Employees`
            }
        }

        public IEnumerable<EventCategory> GetAllCategories()
        {
            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                return session.Query<EventCategory>().Take(100);
            }
        }

        public void Save(Organizer obj)
        {

            // initializes document store, by connecting to server and downloading various configurations

            using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
            {
                session.Store(obj); // stores employee in session, assigning it to a collection `Employees`
                session.SaveChanges(); // sends all changes to server
            }

        }

        public IEnumerable<Organizer> GetAllOrganizers()
        {
            var list = new List<Organizer>();
            int i = 0;
            while (list.Count%100==0)
            {
                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    list.AddRange(session.Query<Organizer>().Skip(i*100).Take(100));
                }
                i++;
            }
            return list;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            var list = new List<Event>();
            int i = 0;
            while (list.Count % 100 == 0)
            {
                using (IDocumentSession session = store.OpenSession()) // opens a session that will work in context of 'DefaultDatabase'
                {
                    list.AddRange(session.Query<Event>().Skip(i * 100).Take(100));
                }
                i++;
            }
            return list;
        }
    }
}
