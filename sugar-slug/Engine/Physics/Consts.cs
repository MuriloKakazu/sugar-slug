using SugarSlug.Engine.Maths;
using SugarSlug.Engine.Maths.Model;

namespace SugarSlug.Engine.Physics {
    public static class Consts {
        static Consts() {
            EarthGravityMagnitude = 9.80665f;
            AirDensity = 1.225f;
            WaterDensity = 0.997f;
            PixelsInAMeter = 3779.5275590551f;
            EarthGravity = new Vector(0, -EarthGravityMagnitude, 0);
        }

        public static Vector EarthGravity { get; private set; }
        public static float EarthGravityMagnitude { get; private set; }
        public static float AirDensity { get; private set; }
        public static float WaterDensity { get; private set; }
        public static float PixelsInAMeter { get; private set; }
    }
}
