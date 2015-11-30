using Orchard.UI.Resources;

namespace js.imagesLoaded {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            // defaults at common highlight
            manifest.DefineScript("imagesLoaded")
                .SetDependencies("jQuery", "jQueryMigrate")
                .SetUrl("imagesloaded.pkgd.min.js", "imagesloaded.pkgd.js")                
                .SetVersion("3.1.8");
        }
    }
}
