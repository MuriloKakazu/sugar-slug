using SugarSlug.Engine.Maths.Model;
using System;

namespace SugarSlug.Engine.Maths.Helpers {
    public static class VectorHelper {
        const float EPSILON = 0.0001f;
        const int EPSILON_DECIMAL_DIGITS = 4;

        public static Vector GetScalarOf(float value) => new Vector(
            x: value,
            y: value,
            z: value
        );

        public static float GetMagnitude(Vector vector) => (float)
            Math.Sqrt(
                Math.Pow(vector.X, 2) +
                Math.Pow(vector.Y, 2) +
                Math.Pow(vector.Z, 2)
        );

        public static Vector GetDirection(Vector vector) => 
            GetNormalized(vector);

        public static Vector GetNormalized(Vector vector) {
            var magnitude = vector.Magnitude;

            if (magnitude == 0) {
                return Vector.Zero;
            }

            return new Vector(
                vector.X / magnitude,
                vector.Y / magnitude,
                vector.Z / magnitude
            );
        }

        public static Vector GetOpposite(Vector vector) => 
            VectorOperatorHelper.Opposite(vector);

        // if Magnitude in range: (0.9995 - 1.0005)
        // it's considered normalized
        public static bool GetIsNormalized(Vector vector) => 
            Math.Abs(1 - vector.Magnitude) <= EPSILON;

        public static String Format(Vector vector) {
            var digits = EPSILON_DECIMAL_DIGITS;
            var x = Math.Round(vector.X, digits);
            var y = Math.Round(vector.Y, digits);
            var z = Math.Round(vector.Z, digits);

            return String.Format($"({x}, {y}, {z})");
        }

        public static Vector PointedAt(Vector vector, Vector position) => 
            vector.Magnitude * position.Direction;

        public static float DistanceTo(Vector vector, Vector position) => 
            (vector - position).Magnitude;

        public static bool AreEqual(object vectorA, object vectorB) {
            var areVectors = vectorA is Vector && vectorB is Vector;

            if (areVectors) {
                return AreEqual((Vector)vectorA, (Vector)vectorB);
            }

            return false;
        }

        public static bool AreEqual(Vector vectorA, Vector vectorB) {
            if (ReferenceEquals(vectorA, vectorB)) {
                return true;
            }

            return vectorA.GetHashCode() == vectorB.GetHashCode();
        }
    }
}
