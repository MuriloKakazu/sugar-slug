using SugarSlug.Engine.Maths.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarSlug.Engine.Physics.Model {
    public class Transform {
        public Vector Center { get; protected set; }
        public Vector Scale { get; protected set; }
        public Vector Size { get; protected set; }
        public Vector Position { get; protected set; }
        public Vector Rotation { get; protected set; }

        public Transform() {
            Scale = 1f;
            Size = 0f;
            Position = 0f;
            Rotation = 0f;
            Center = 0f;
        }

        public Transform Translate(Vector offset, Space relativeTo = Space.Self) {
            if (relativeTo == Space.Self) {

            } else {
                Position += offset;
            }

            return this;
        }

        public Transform Rotate(float angle, Axis axis, Space relativeTo = Space.Self) {
            if (relativeTo == Space.Self) {

            } else {
                Rotation += (angle, axis);
            }

            return this;
        }

        public Transform Resize(Vector size) {
            Size = size;

            return this;
        }

        public Transform SetPosition(Vector position) {
            Position = position;

            return this;
        }

        public Transform SetRotation(Vector rotation) {
            Rotation = rotation;

            return this;
        }

        public Transform SetCenter(Vector position) {
            Center = position;

            return this;
        }
    }
}
