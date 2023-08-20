using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Models
{
    public class ClientsModel:Clients
    {
        public ClientsModel(Clients clientsToCopy)
        {
            ClientID = clientsToCopy.ClientID;
            CFName = clientsToCopy.CFName;
            CLName = clientsToCopy.CLName;
            Phone = clientsToCopy.Phone;
            Zipcode = clientsToCopy.Zipcode;
            City = clientsToCopy.City;
            Street = clientsToCopy.Street;
            ApartmentNumber = clientsToCopy.ApartmentNumber;
        }
    }
}
