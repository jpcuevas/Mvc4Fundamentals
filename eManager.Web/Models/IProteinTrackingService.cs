using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Web.Models
{
    public interface IProteinTrackingService
    {
        int Total { get; set; }
        int Goal { get; set; }
        void AddProtein(int amount);
    }
}
