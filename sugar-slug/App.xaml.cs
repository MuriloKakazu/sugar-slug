using SugarSlug.Debug;
using SugarSlug.Engine;
using SugarSlug.Engine.Environments;
using SugarSlug.Engine.Physics;
using SugarSlug.IO;
using SugarSlug.Metadata;
using SugarSlug.Metadata.Loader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SugarSlug {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            BuildEnsurer.EnsureDirectoriesExist(
                new List<String> {
                    @"logs",
                    @"saves",
                    @"assets",
                    @"assets\audio",
                    @"assets\audio\metadata",
                    @"assets\sprites",
                    @"assets\sprites\metadata",
                    @"assets\characters",
                    @"assets\weapons",
                    @"assets\projectiles",
                }
            );

            AssetLoader.Instance.EncacheAllRecursively(Paths.Assets);

            Console.WriteLine($"Loaded files into cache: {Cache.Instance.Size}");

            // temp
            Game.Scene = new Scene() {
                Environment = new CustomEnvironment(Consts.EarthGravity, Consts.AirDensity),
                Scale = 40.0f,
            };
        }
    }
}
