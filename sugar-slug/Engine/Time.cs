using System;
using System.Diagnostics;
using System.Timers;
using SystemTimer = System.Timers.Timer;

namespace SugarSlug.Engine {
    public static class Time {
        public class TimeEventArgs : EventArgs {
            public float Delta;

            public TimeEventArgs(float delta) {
                Delta = delta;
            }
        }

        public static float PHYSICS_EPSILON => 0.02f;
        public static float RENDER_EPSILON => 0.001f;

        public static event EventHandler<TimeEventArgs> PhysicsUpdated;
        public static event EventHandler<TimeEventArgs> RenderUpdated;

        static SystemTimer PhysicsTimer { get; set; }
        static Stopwatch PhysicsStopwatch { get; set; }

        static SystemTimer RenderTimer { get; set; }
        static Stopwatch RenderStopwatch { get; set; }

        static Time() {
            SetupPhysicsTimer();
            SetupRenderTimer();
        }

        static void SetupPhysicsTimer() {
            PhysicsStopwatch = new Stopwatch();
            PhysicsTimer = new SystemTimer() {
                Interval = PHYSICS_EPSILON
            };

            PhysicsTimer.Elapsed += PhysicsTick;
            PhysicsTimer.Start();
            PhysicsStopwatch.Start();
        }

        static void SetupRenderTimer() {
            RenderStopwatch = new Stopwatch();
            RenderTimer = new SystemTimer() {
                Interval = RENDER_EPSILON
            };

            RenderTimer.Elapsed += RenderTick;
            RenderTimer.Start();
            RenderStopwatch.Start();
        }

        public static void Resume() {
            ResumePhysics();
            ResumeRender();
        }

        public static void ResumePhysics() {
            PhysicsTimer.Start();
            PhysicsStopwatch.Reset();
            PhysicsStopwatch.Start();
        }

        public static void ResumeRender() {
            PhysicsTimer.Start();
            PhysicsStopwatch.Reset();
            PhysicsStopwatch.Start();
        }

        public static void Pause() {
            PausePhysics();
            PauseRender();
        }

        public static void PausePhysics() {
            PhysicsTimer.Stop();
            PhysicsStopwatch.Stop();
        }

        public static void PauseRender() {
            RenderTimer.Stop();
            RenderStopwatch.Stop();
        }

        static void PhysicsTick(object sender, ElapsedEventArgs e) {
            DispatchPhysicsEvents(sender);
        }

        static void RenderTick(object sender, ElapsedEventArgs e) {
            DispatchRenderEvents(sender);
        }

        static void DispatchPhysicsEvents(object sender) {
            PhysicsStopwatch.Stop();
            float delta = PhysicsStopwatch.ElapsedMilliseconds / 1000f;
            PhysicsStopwatch.Reset();
            PhysicsStopwatch.Start();

            // dispatch
            PhysicsUpdated(sender, new TimeEventArgs(delta));
        }

        static void DispatchRenderEvents(object sender) {
            RenderStopwatch.Stop();
            float delta = RenderStopwatch.ElapsedMilliseconds / 1000f;
            RenderStopwatch.Reset();
            RenderStopwatch.Start();

            // dispatch
            RenderUpdated(sender, new TimeEventArgs(delta));
        }
    }
}
