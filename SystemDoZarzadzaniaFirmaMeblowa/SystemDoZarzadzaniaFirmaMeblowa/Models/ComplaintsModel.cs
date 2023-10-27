using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Models
{
   public class ComplaintsModel:Complaints
    {
        public ComplaintsModel(Complaints complaintsToCopy)
        {
            IdComplaint = complaintsToCopy.IdComplaint;
            OrderID = complaintsToCopy.OrderID;
            Reason = complaintsToCopy.Reason;
        }
    }
}
