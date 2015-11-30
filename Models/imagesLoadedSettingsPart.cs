﻿using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js.imagesLoaded.Models
{
    public class imagesLoadedSettingsPart : ContentPart<imagesLoadedSettingsPartRecord> {    
        public bool AutoEnable
        {
            get { return Record.AutoEnable; }
            set { Record.AutoEnable = value; }
        }
        public bool AutoEnableAdmin
        {
            get { return Record.AutoEnableAdmin; }
            set { Record.AutoEnableAdmin = value; }
        }
    }
}