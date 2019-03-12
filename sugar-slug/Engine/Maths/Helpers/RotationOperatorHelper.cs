using SugarSlug.Engine.Maths.Model;

namespace SugarSlug.Engine.Maths.Helpers {
    public static class RotationOperatorHelper {
        public static Vector Rotate(Vector vector, (float angle, Axis axis) offset) => 
            RotationHelper.Rotate(vector, offset.angle, offset.axis);
    }
}
