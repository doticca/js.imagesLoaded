using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js.imagesLoaded.Models
{
    public class imagesLoadedSettingsPartRecord: ContentPartRecord
    {
        public virtual bool AutoEnable { get; set; }
        public virtual bool AutoEnableAdmin { get; set; }

        public imagesLoadedSettingsPartRecord()
        {
            AutoEnable = true;
            AutoEnableAdmin = false;
        }
    }
}