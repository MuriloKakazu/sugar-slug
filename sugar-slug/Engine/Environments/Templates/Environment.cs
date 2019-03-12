using SugarSlug.Engine.Maths.Model;

namespace SugarSlug.Engine.Environments.Templates {
    public abstract class Environment {
        public abstract Vector Gravity { get; }
        public abstract float Density { get; }
    }
}
