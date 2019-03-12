using Newtonsoft.Json;
using System;
using Image = System.Windows.Media.Imaging.BitmapImage;

namespace SugarSlug.Metadata.Model {
    public class Sprite : Asset {
        [JsonRequired]
        public new AssetType Type =>
            AssetType.Sprite;
        [JsonRequired]
        public Uri ImageSource { get; set; }
        [JsonIgnore]
        public Image Image { get; set; }
    }
}
