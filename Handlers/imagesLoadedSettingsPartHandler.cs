using js.imagesLoaded.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace js.imagesLoaded.Handlers
{
    public class imagesLoadedSettingsPartHandler: ContentHandler {
        public imagesLoadedSettingsPartHandler(IRepository<imagesLoadedSettingsPartRecord> repository)
        {
            T = NullLocalizer.Instance;
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<imagesLoadedSettingsPart>("Site"));

            OnInitializing<imagesLoadedSettingsPart>((context, part) =>
            {
                part.AutoEnable = true;
                part.AutoEnableAdmin = true;
            });
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("imagesLoaded")));
        }
    }
}