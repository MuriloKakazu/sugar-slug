using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SugarSlug.Engine.Maths;
using SugarSlug.Engine.Maths.Model;

namespace SugarSlugTests.Engine.Maths {
    [TestClass]
    public class VectorTests {
        [TestMethod]
        public void ShouldSumPositiveVectors() {
            // given
            Vector vector1 = new Vector(10f, 20f, 30f);
            Vector vector2 = new Vector(20f, 30f, 40f);

            // when
            Vector sum = vector1 + vector2;

            // then
            Assert.AreEqual(expected: 30f, actual: sum.X);
            Assert.AreEqual(expected: 50f, actual: sum.Y);
            Assert.AreEqual(expected: 70f, actual: sum.Z);
        }

        [TestMethod]
        public void ShouldSumNegativeVectors() {
            // given
            Vector vector1 = new Vector(-10f, -20f, -30f);
            Vector vector2 = new Vector(-20f, -30f, -40f);

            // when
            Vector sum = vector1 + vector2;

            // then
            Assert.AreEqual(expected: -30f, actual: sum.X);
            Assert.AreEqual(expected: -50f, actual: sum.Y);
            Assert.AreEqual(expected: -70f, actual: sum.Z);
        }

        [TestMethod]
        public void ShouldSubtractPositiveVectors() {
            // given
            Vector vector1 = new Vector(5f, 10f, 90f);
            Vector vector2 = new Vector(20f, 30f, 40f);

            // when
            Vector diff = vector1 - vector2;

            // then
            Assert.AreEqual(expected: -15f, actual: diff.X);
            Assert.AreEqual(expected: -20f, actual: diff.Y);
            Assert.AreEqual(expected: 50f, actual: diff.Z);
        }

        [TestMethod]
        public void ShouldSubtractNegativeVectors() {
            // given
            Vector vector1 = new Vector(-10f, -50f, -5f);
            Vector vector2 = new Vector(-20f, -30f, -40f);

            // when
            Vector diff = vector1 - vector2;

            // then
            Assert.AreEqual(expected: 10f, actual: diff.X);
            Assert.AreEqual(expected: -20f, actual: diff.Y);
            Assert.AreEqual(expected: 35f, actual: diff.Z);
        }

        [TestMethod]
        public void ShouldPerformScalarMultiplication() {
            // given
            Vector vector1 = new Vector(10f, 20f, 30f);
            float scale = 2.0f;

            // when
            Vector scaledVector = vector1 * scale;

            // then
            Assert.AreEqual(expected: 20f, actual: scaledVector.X);
            Assert.AreEqual(expected: 40f, actual: scaledVector.Y);
            Assert.AreEqual(expected: 60f, actual: scaledVector.Z);
        }

        [TestMethod]
        public void ShouldPerformScalarDivision() {
            // given
            Vector vector1 = new Vector(10f, 20f, 10f);
            float div = 2.0f;

            // when
            Vector scaledVector = vector1 / div;

            // then
            Assert.AreEqual(expected: 5f, actual: scaledVector.X);
            Assert.AreEqual(expected: 10f, actual: scaledVector.Y);
            Assert.AreEqual(expected: 5f, actual: scaledVector.Z);
        }

        [TestMethod]
        public void ShouldPerformCrossProduct() {
            // given
            Vector vector1 = new Vector(1f, 2f, 3f);
            Vector vector2 = new Vector(-1f, 2f, 1f);

            // when
            Vector crossProduct = vector1 * vector2;

            // then
            Assert.AreEqual(expected: -4f, actual: crossProduct.X);
            Assert.AreEqual(expected: -4f, actual: crossProduct.Y);
            Assert.AreEqual(expected: 4f, actual: crossProduct.Z);

            // because
            /*
             
             |  i,  j,  k |
             |  1,  2,  3 |  = [2i + (-3j) +2k - (6i + 1j + (-2k))] = [(-4i) +  (-4j) + 4k]
             | -1,  2,  1 |

             */
        }

        [TestMethod]
        public void ShouldPerformDotProduct() {
            // given
            Vector vector1 = new Vector(1f, 2f, 3f);
            Vector vector2 = new Vector(-1f, 2f, 1f);

            // when
            float dotProduct = vector1.Dot(vector2);

            // then
            Assert.AreEqual(expected: 6f, actual: dotProduct);

            // because
            /*
             
              (1, 2, 3) . (-1, 2, 1) = [(1*(-1)) + (2*2) + (3*1)] = 6
            
             */
        }

        [TestMethod]
        public void ShouldNormalizeVector() {
            // given
            Vector vector = new Vector(10f, 10f, 0f);

            // when
            Vector normalizedVector = vector.Normalized;

            // then
            Assert.AreEqual(expected: 0.7071f, actual: normalizedVector.X, delta: 0.0001f);
            Assert.AreEqual(expected: 0.7071f, actual: normalizedVector.Y, delta: 0.0001f);
            Assert.AreEqual(expected: 0f, actual: normalizedVector.Z);
            // and - magnitude should be 1
            Assert.IsTrue(normalizedVector.IsNormalized);
        }

        [TestMethod]
        public void ShouldPointVectorToAnotherDirection() {
            // given
            Vector vector = new Vector(10f, 10f, 0f);
            Vector direction = Vector.Left;

            // when
            Vector redirectedVector = vector.PointedAt(direction);

            // then - magnitude should be kept
            Assert.AreEqual(expected: vector.Magnitude, actual: redirectedVector.Magnitude, delta: 0.0001f);
            // and - vector direction should be pointed to the left
            Assert.AreEqual(expected: Vector.Left.X, actual: redirectedVector.Direction.X, delta: 0.0001f);
        }
    }
}
