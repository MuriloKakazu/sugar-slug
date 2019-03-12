using SugarSlug.Engine.Maths.Model;
using System;

namespace SugarSlug.Engine.Maths.Helpers {
    public static class RotationHelper {
        public static Vector Rotate(Vector vector, float angle, Axis axis) {
            switch (axis) {
                case Axis.X:
                    return RotateX(vector, angle);
                case Axis.Y:
                    return RotateY(vector, angle);
                case Axis.Z:
                    return RotateZ(vector, angle);
                default: break;
            }
            throw new InvalidOperationException();
        }

        static Vector RotateX(Vector vector, float angle) => 
            RotateX(vector, Math.Sin(angle), Math.Cos(angle));

        static Vector RotateX(Vector vector, double sine, double cosine) => 
            RotateX(vector, (float)sine, (float)cosine);

        static Vector RotateX(Vector vector, float sine, float cosine) {
            var x = vector.X;
            var y = vector.Y;
            var z = vector.Z;

            y = y * cosine - z * sine;
            z = y * sine + z * cosine;

            return new Vector(x, y, z);
        }

        static Vector RotateY(Vector vector, float angle) => 
            RotateY(vector, Math.Sin(angle), Math.Cos(angle));

        static Vector RotateY(Vector vector,  double sine, double cosine) => 
            RotateY(vector, (float)sine, (float)cosine);

        static Vector RotateY(Vector vector,  float sine, float cosine) {
            var x = vector.X;
            var y = vector.Y;
            var z = vector.Z;

            x = z * sine + x * cosine;
            z = z * cosine - x * sine;

            return new Vector(x, y, z);
        }

        static Vector RotateZ(Vector vector, float angle) => 
            RotateZ(vector, Math.Sin(angle), Math.Cos(angle));

        static Vector RotateZ(Vector vector, double sine, double cosine) => 
            RotateZ(vector, (float)sine, (float)cosine);

        static Vector RotateZ(Vector vector, float sine, float cosine) {
            var x = vector.X;
            var y = vector.Y;
            var z = vector.Z;

            x = x * cosine - y * sine;
            y = x * sine + y * cosine;

            return new Vector(x, y, z);
        }

        // TO DO
        static float GetRotation(Vector vector, Axis axis) {
            throw new NotImplementedException();
        }
    }
}
