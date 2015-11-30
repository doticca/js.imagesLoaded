using Orchard.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js.imagesLoaded
{
    public class imagesLoadedMigrations : DataMigrationImpl {    
        public int Create()
        {
            SchemaBuilder.CreateTable(
                "imagesLoadedSettingsPartRecord",
                table => table
                             .ContentPartRecord()
                             .Column<bool>("AutoEnable", c => c.WithDefault(true))
                             .Column<bool>("AutoEnableAdmin", c => c.WithDefault(false))
                );
            return 1;
        }

    }
}