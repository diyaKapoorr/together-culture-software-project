using MySql.Data.MySqlClient;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace member_space
{
    internal class EventMethods : DatabaseConnection
    {
        public List<EventData> GetEvents() 
        {
            List<EventData> events = new List<EventData>();
            using (var connection = get_Connection()) 
            {
                connection.Open();

                string query = "SELECT EventActivityID, AdminID, Address, " +
                        "Postcode, BuildingName,Type,Description" +
                        ",EventDate,Duration,MaxCapacity,EventName FROM eventactivity";
                using (var command = new MySqlCommand(query, connection)) 
                {
                    using (var reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            var eventInstance = new EventData
                            {
                                EventID = reader.GetInt32("EventActivityID"),
                                AdminID = reader.GetInt32("AdminID"),
                                Address = reader.GetString("Address"),
                                Postcode = reader.GetString("PostCode"),
                                BuildingName = reader.GetString("BuildingName"),
                                Type = reader.GetString("Type"),
                                Description = reader.GetString("Description"),
                                Date = reader.GetDateTime("EventDate"),
                                Duration = reader.GetInt32("Duration"),
                                MaxCapacity = reader.GetInt32("MaxCapacity"),
                                EventName = reader.GetString("EventName"),
                            };
                            events.Add(eventInstance);
            
                        }
                    }
                }
            }
            return events;
        }
        //public bool UpdateEvent(EventData updatedEvent) 
        //{
          //  using (var connection = get_Connection()) 
          //  {
            //    connection.Open();
             //   string query = @"UPDATE eventactivity SET AdminID = @AdminID,EventID = Event";
           // }
        //}
       
        
    }
   
}
