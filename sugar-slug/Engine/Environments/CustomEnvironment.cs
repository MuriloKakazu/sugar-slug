using SugarSlug.Engine.Maths.Model;
using Environment = SugarSlug.Engine.Environments.Templates.Environment;

namespace SugarSlug.Engine.Environments {
    public class CustomEnvironment : Environment {
        Vector customGravity;
        float customDensity;

        public CustomEnvironment(Vector gravity, float density) {
            customGravity = gravity;
            customDensity = density;
        }

        public override Vector Gravity => customGravity;

        public override float Density => customDensity;
    }
}