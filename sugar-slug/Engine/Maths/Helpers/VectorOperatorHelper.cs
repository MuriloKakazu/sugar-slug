using SugarSlug.Engine.Maths.Model;

namespace SugarSlug.Engine.Maths.Helpers {
    public static class VectorOperatorHelper {
        public static Vector Sum(Vector vectorA, Vector vectorB) => new Vector(
            vectorA.X + vectorB.X,
            vectorA.Y + vectorB.Y,
            vectorA.Z + vectorB.Z
        );

        public static Vector Subtract(Vector vectorA, Vector vectorB) => new Vector(
            vectorA.X - vectorB.X,
            vectorA.Y - vectorB.Y,
            vectorA.Z - vectorB.Z
        );

        public static Vector Product(Vector vector, float constant) => new Vector(
            vector.X * constant,
            vector.Y * constant,
            vector.Z * constant
        );

        public static Vector Product(float constant, Vector vector) => 
            vector * constant;

        public static Vector Cross(Vector vectorA, Vector vectorB) => new Vector(
           (vectorA.Y * vectorB.Z) - (vectorA.Z * vectorB.Y),
           (vectorA.Z * vectorB.X) - (vectorA.X * vectorB.Z),
           (vectorA.X * vectorB.Y) - (vectorA.Y * vectorB.X)
        );

        public static float Dot(Vector vectorA, Vector vectorB) => 
            (vectorA.X * vectorB.X) +
            (vectorA.Y * vectorB.Y) +
            (vectorA.Z * vectorB.Z);

        public static Vector Scale(Vector vectorA, Vector vectorB) => new Vector(
            vectorA.X * vectorB.X,
            vectorA.Y * vectorB.Y,
            vectorA.Z * vectorB.Z
        );

        public static Vector Quotient(Vector dividend, float divisor) => new Vector(
            dividend.X / divisor,
            dividend.Y / divisor,
            dividend.Z / divisor
        );

        public static Vector Opposite(Vector vector) => new Vector(
            -vector.X, 
            -vector.Y, 
            -vector.Z
        );
    }
}
