using Microsoft.VisualStudio.TestTools.UnitTesting;
using SugarSlug.Engine.Maths;
using SugarSlug.Engine.Maths.Model;
using SugarSlug.Engine.Physics;
using SugarSlug.Engine.Physics.Model;

namespace SugarSlugTests.Engine.Physics {
    [TestClass]
    public class RigidBodyTests {
        [TestMethod]
        public void ShouldNotAllowMovement_WhenFrozen() {
            // given
            RigidBody body = new RigidBody() {
                Mass = 10f,
                AllowMovement = true
            };

            // when
            body.Freeze();

            // then
            Assert.AreEqual(false, body.AllowMovement);
        }
    }
}
