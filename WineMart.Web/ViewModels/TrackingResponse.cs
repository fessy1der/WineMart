using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class TrackingResponse
    {
        public List<InventoryTrackingViewModel> InventoryTrackings { get; set; }
        public List<DateTime> Timeline { get; set; }
    }
}
