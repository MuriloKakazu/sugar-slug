using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarSlug.IO {
    public static class Paths {
        public static Uri ApplicationDirectory
            => new Uri(AppDomain.CurrentDomain.BaseDirectory);
        public static Uri Assets
            => new Uri($@"{ApplicationDirectory}assets\");
        public static Uri Audio
            => new Uri($@"{Assets}audio\");
        public static Uri AudioMetadata
            => new Uri($@"{Audio}metadata\");
        public static Uri Sprites
            => new Uri($@"{Assets}sprites\");
        public static Uri SpritesMetadata
            => new Uri($@"{Sprites}metadata\");
        public static Uri CharactersMetadata
            => new Uri($@"{Assets}characters\");
        public static Uri WeaponsMetadata
            => new Uri($@"{Assets}weapons\");
        public static Uri ProjectilesMetadata
            => new Uri($@"{Assets}projectiles\");
        public static Uri SaveGames
            => new Uri($@"{ApplicationDirectory}saves\");
        public static Uri Logs
            => new Uri($@"{ApplicationDirectory}logs\");
        public static Uri SettingsFile
            => new Uri($"{ApplicationDirectory}settings.json");
    }
}
