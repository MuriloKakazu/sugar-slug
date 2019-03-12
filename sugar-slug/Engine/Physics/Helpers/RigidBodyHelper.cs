using SugarSlug.Engine.Maths.Model;
using SugarSlug.Engine.Physics.Model;
using System;

namespace SugarSlug.Engine.Physics.Helpers {
    public static class RigidBodyHelper {
        public static RigidBody ResetToDefault(RigidBody body) {
            body.Transform = new Transform();

            body.Mass = 1f;
            body.DragCoefficient = 0.5f;

            Freeze(body);

            return body;
        }

        public static RigidBody Stop(RigidBody body) {
            body.ExternalForces = 0f;
            body.Force = 0f;
            body.Acceleration = 0f;
            body.Velocity = 0f;
            body.InputVelocity = 0f;
            body.Drag = 0f;

            return body;
        }

        public static RigidBody Freeze(RigidBody body) {
            Stop(body);

            body.AllowMovement = false;
            body.AllowRotation = false;
            body.AllowCollision = false;
            body.AllowGravity = false;
            body.AllowDrag = false;

            return body;
        }

        public static RigidBody Unfreeze(RigidBody body) {
            body.AllowMovement = true;
            body.AllowRotation = true;
            body.AllowCollision = true;
            body.AllowGravity = true;
            body.AllowDrag = true;

            return body;
        }

        public static Vector SolveDrag(RigidBody body) {
            var velocity = body.Velocity;
            var size = body.Size;
            var dragCoefficient = body.DragCoefficient;
            var environmentDensity = Game.Scene.Environment.Density;
            var velocitySquared = (float)Math.Pow(velocity.Magnitude, 2);
            var affectedArea = (size.X * size.Y) / Consts.PixelsInAMeter;
            var oppositeDirection = velocity.Direction.Opposite;

            var drag = oppositeDirection * (dragCoefficient * environmentDensity * velocitySquared * affectedArea / 2f);

            return drag;
        }

        public static Vector SolveForce(RigidBody body) {
            var force = Vector.Zero;
            force += body.ExternalForces;

            if (body.AllowDrag) {
                force += body.Drag;
            }

            if (body.AllowGravity) {
                force += body.Weight;
            }

            return force;
        }

        public static RigidBody UpdatePhysics(RigidBody body, Time.TimeEventArgs t) {
            if (body.AllowMovement) {

                body.Drag = SolveDrag(body);
                body.Force = SolveForce(body);
                body.Acceleration = body.Force / body.Mass;
                body.Velocity += body.Acceleration * t.Delta;

                var movement = (body.Velocity + body.InputVelocity) * t.Delta;
                body.Transform.Translate(offset: movement, relativeTo: Space.World);
            }

            return body;
        }
    }
}
