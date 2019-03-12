using SugarSlug.Engine.Maths.Model;
using SugarSlug.Engine.Physics.Helpers;

namespace SugarSlug.Engine.Physics.Model {
    public class RigidBody {
        public Vector ExternalForces { get; set; }

        public Vector Force { get; set; }

        public Vector Acceleration { get; set; }

        public Vector Velocity { get; set; }

        public Vector InputVelocity { get; set; }

        public Vector Drag { get; set; }

        public Transform Transform { get; set; } 

        public Vector Size => 
            Transform.Size;

        public Vector SizeScaled => 
            Size.Scale(Scale);

        public Vector Position => 
            Transform.Position;

        public Vector PositionScaled => 
            Position.Scale(Scale);

        public Vector Scale => 
            Transform.Scale;

        public Vector Weight => 
            Game.Scene.Environment.Gravity * Mass;

        public float Mass { get; set; }

        public float DragCoefficient { get; set; }

        public bool AllowMovement { get; set; }

        public bool AllowCollision { get; set; }

        public bool AllowRotation { get; set; }

        public bool AllowGravity { get; set; }

        public bool AllowDrag { get; set; }

        public bool IsAccelerating => Acceleration.Magnitude > 0;

        public RigidBody() {
            RigidBodyHelper.ResetToDefault(this);

            Time.PhysicsUpdated += PhysicsUpdated;
        }

        public RigidBody ApplyForce(Vector force) {
            ExternalForces += force;
            return this;
        }

        public RigidBody Freeze() => 
            RigidBodyHelper.Freeze(this);

        public RigidBody Unfreeze() =>
            RigidBodyHelper.Unfreeze(this);

        private void PhysicsUpdated(object sender, Time.TimeEventArgs t) =>
            RigidBodyHelper.UpdatePhysics(this, t);
    }
}
