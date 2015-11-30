using System;
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.Caching;
using Orchard.Environment.Extensions;
using Orchard.MediaLibrary.Services;
using js.imagesLoaded.Models;

namespace js.imagesLoaded.Services
{
    public interface IimagesLoadedService : IDependency
    {
        bool GetAutoEnable();
        bool GetAutoEnableAdmin();
    }

    public class imagesLoadedService : IimagesLoadedService
    {
        private readonly IWorkContextAccessor _wca;
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;
        private readonly IMediaLibraryService _mediaService;

        private const string ScriptsFolder = "scripts";

        public imagesLoadedService(IWorkContextAccessor wca, ICacheManager cacheManager, ISignals signals, IMediaLibraryService mediaService)
        {
            _wca = wca;
            _cacheManager = cacheManager;
            _signals = signals;
            _mediaService = mediaService;
        }

        public bool GetAutoEnable()
        {
            return _cacheManager.Get(
                "js.imagesLoaded.AutoEnable",
                ctx =>
                {
                    ctx.Monitor(_signals.When("js.imagesLoaded.Changed"));
                    WorkContext workContext = _wca.GetContext();
                    var imagesLoadedSettings =
                        (imagesLoadedSettingsPart)workContext
                                                  .CurrentSite
                                                  .ContentItem
                                                  .Get(typeof(imagesLoadedSettingsPart));
                    return imagesLoadedSettings.AutoEnable;
                });
        }

        public bool GetAutoEnableAdmin()
        {
            return _cacheManager.Get(
                "js.imagesLoaded.AutoEnableAdmin",
                ctx =>
                {
                    ctx.Monitor(_signals.When("js.imagesLoaded.Changed"));
                    WorkContext workContext = _wca.GetContext();
                    var imagesLoadedSettings =
                        (imagesLoadedSettingsPart)workContext
                                                  .CurrentSite
                                                  .ContentItem
                                                  .Get(typeof(imagesLoadedSettingsPart));
                    return imagesLoadedSettings.AutoEnableAdmin;
                });
        }

    }
}