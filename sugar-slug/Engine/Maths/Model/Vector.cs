using SugarSlug.Engine.Maths.Helpers;
using System;

namespace SugarSlug.Engine.Maths.Model {
    public partial class Vector {
        public static Vector Zero => new Vector(0, 0, 0);

        public static Vector One => new Vector(1, 1, 1);

        public static Vector Up => new Vector(0, 1, 0);

        public static Vector Down => new Vector(0, -1, 0);

        public static Vector Left => new Vector(-1, 0, 0);

        public static Vector Right => new Vector(1, 0, 0);

        public static Vector Forward => new Vector(0, 0, 1);

        public static Vector Backward => new Vector(0, 0, -1);

        public static Vector ScalarOf(float value) => VectorHelper.GetScalarOf(value);

        public static Vector operator +(Vector vectorA, Vector vectorB) => 
            VectorOperatorHelper.Sum(vectorA, vectorB);

        public static Vector operator -(Vector vectorA, Vector vectorB) => 
            VectorOperatorHelper.Subtract(vectorA, vectorB);

        public static Vector operator *(Vector vector, float factor) => 
            VectorOperatorHelper.Product(vector, factor);

        public static Vector operator *(Vector vector, double factor) =>
            VectorOperatorHelper.Product(vector, (float) factor);

        public static Vector operator *(float factor, Vector vector) => 
            VectorOperatorHelper.Product(vector, factor);

        public static Vector operator *(double factor, Vector vector) =>
            VectorOperatorHelper.Product(vector, (float) factor);

        public static Vector operator *(Vector vectorA, Vector vectorB) => 
            VectorOperatorHelper.Cross(vectorA, vectorB);

        public static Vector operator /(Vector vector, float divisor) => 
            VectorOperatorHelper.Quotient(vector, divisor);

        public static Vector operator -(Vector vector) => 
            VectorOperatorHelper.Opposite(vector);

        public static bool operator ==(Vector vectorA, Vector vectorB) =>
            vectorA.Equals(vectorB);

        public static bool operator !=(Vector vectorA, Vector vectorB) => 
            !vectorA.Equals(vectorB);

        public static Vector operator +(Vector vector, (float angle, Axis axis) offset) {
            return RotationOperatorHelper.Rotate(vector, offset);
        }

        public static Vector operator -(Vector vector, (float angle, Axis axis) offset) {
            return RotationOperatorHelper.Rotate(vector, (-offset.angle, offset.axis));
        }

        public static implicit operator (float, float, float) (Vector vector) =>
            (vector.X, vector.Y, vector.Z);

        public static implicit operator (float, float) (Vector vector) =>
            (vector.X, vector.Y);

        public static implicit operator Vector((float x, float y, float z) tuple) => 
            new Vector(tuple.x, tuple.y, tuple.z);

        public static implicit operator Vector((float x, float y) tuple) => 
            new Vector(tuple.x, tuple.y);

        public static implicit operator Vector(float value) =>
            ScalarOf(value);
    }

    public partial class Vector {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Magnitude => 
            VectorHelper.GetMagnitude(this);

        public Vector Direction => 
            VectorHelper.GetDirection(this);

        public Vector Opposite => 
            VectorHelper.GetOpposite(this);

        public Vector Normalized => 
            VectorHelper.GetNormalized(this);

        public bool IsNormalized => 
            VectorHelper.GetIsNormalized(this);

        public string Format() => 
            VectorHelper.Format(this);

        public Vector PointedAt(Vector position) => 
            VectorHelper.PointedAt(this, position);

        public float DistanceTo(Vector position) => 
            VectorHelper.DistanceTo(this, position);

        public Vector(Vector vector) =>
            Set(vector);

        public Vector(float value = 0f) => 
            ScalarOf(value);

        public Vector(float x, float y, float z) =>
            Set(x, y, z);

        public Vector(double x, double y, double z) =>
            Set(x, y, z);

        public Vector(float x, float y) : this(x, y, 0) { }

        public Vector(double x, double y) : this(x, y, 0) { }

        public Vector Set(float x, float y, float z) {
            (X, Y, Z) = (x, y, z);
            return this;
        }

        public Vector Set(double x, double y, double z) =>
            Set((float)x, (float)y, (float)z);

        public Vector Set(Vector vector) => 
            Set(vector.X, vector.Y, vector.Z);

        public Vector Rotate(float angle, Axis axis) => 
            this + (angle, axis);

        public Vector Sum(Vector sum) =>
            this + sum;

        public Vector Subtract(Vector subtraction) =>
            this - subtraction;

        public Vector Multiply(float factor) =>
            this * factor;

        public float Dot(Vector vector) =>
            VectorOperatorHelper.Dot(this, vector);

        public Vector Scale(float scale) =>
            Scale(ScalarOf(scale));

        public Vector Scale(Vector vector) =>
            VectorOperatorHelper.Scale(this, vector);

        public Vector Cross(Vector vector) =>
            this * vector;

        public Vector Divide(float divisor) =>
            this / divisor;

        public override string ToString() => 
            Format();

        public override bool Equals(object comparison) => 
            VectorHelper.AreEqual(this, comparison);

        public override int GetHashCode() {
            return
                X.GetHashCode() +
                Y.GetHashCode() +
                Z.GetHashCode();
        }
    }
}