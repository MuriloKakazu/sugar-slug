using SugarSlug.Engine.Maths;
using SugarSlug.Engine.Maths.Model;
using SugarSlug.Engine.Physics;
using Environment = SugarSlug.Engine.Environments.Templates.Environment;

namespace SugarSlug.Engine.Environments {
    public class EarthLand : Environment {
        public override Vector Gravity {
            get => Consts.EarthGravity;
        }
        public override float Density {
            get => Consts.AirDensity;
        }
    }
}
