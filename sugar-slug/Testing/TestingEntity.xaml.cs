using SugarSlug.Engine;
using SugarSlug.Engine.Input;
using SugarSlug.Engine.Physics;
using SugarSlug.Engine.Physics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vector = SugarSlug.Engine.Maths.Model.Vector;

namespace SugarSlug.Testing {
    /// <summary>
    /// Interaction logic for TestingEntity.xaml
    /// </summary>
    public partial class TestingEntity : UserControl {
        public RigidBody Body { get; set; }
        public bool IsJumping { get; set; }

        public TestingEntity() {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) {
                return;
            }

            Body = new RigidBody() {
                DragCoefficient = Consts.AirDensity,
                Mass = 70,
            };
            Body.Transform.Resize(new Vector(this.ActualWidth, this.ActualHeight, 50));
            Body.Unfreeze();

            Time.RenderUpdated += RenderUpdated;
        }

        private void RenderUpdated(object sender, Time.TimeEventArgs e) {
            this.Dispatcher.Invoke(delegate {
                var scale = Game.Scene.Scale;

                Canvas.SetLeft(this, Body.Position.X * scale);
                Canvas.SetTop(this, -Body.Position.Y * scale);

                Body.Transform.Resize(new Vector(this.ActualWidth, this.ActualHeight, 50));

                var moveX = Input.Get(Engine.Input.InputType.Horizontal);
                var moveY = Input.Get(Engine.Input.InputType.Jump);
                var speed = 5;

                Body.InputVelocity.X = moveX;
                Body.InputVelocity *= speed;

                if (moveY > 0 && !IsJumping) {
                    IsJumping = true;
                    Body.Velocity += (Vector.Up * 15);
                }

                if (Body.Position.Y - Body.Size.Y / scale - 1.5f + 0.001f <= -Application.Current.MainWindow.ActualHeight / scale) {
                    Body.AllowGravity = false;
                    Body.Position.Y = (float) -Application.Current.MainWindow.ActualHeight / scale + Body.Size.Y / scale + 1.5f;
                    Body.Force = Vector.Zero;
                    Body.Acceleration = Vector.Zero;
                    Body.Velocity = Vector.Zero;
                    IsJumping = false;
                } else {
                    Body.AllowGravity = true;
                }
            });
        }
    }
}
