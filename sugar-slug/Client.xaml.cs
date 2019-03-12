using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SugarSlug.Engine;
using SugarSlug.Testing;

namespace SugarSlug {
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : System.Windows.Window {
        TestingEntity Entity { get; set; }

        public Client() {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this)) {
                return;
            }

            Entity = TestingEntity0;

            TestingEntity0.Body.Position.X = 2;
            TestingEntity1.Body.Position.X = 5;
            TestingEntity2.Body.Position.X = 9;

            TestingEntity1.Body.Mass = 50.0f;
            TestingEntity2.Body.Mass = 25.0f;

            Time.RenderUpdated += RenderUpdated;
        }

        private void RenderUpdated(object sender, Time.TimeEventArgs e) {
            this.Dispatcher.Invoke(delegate {
                ForceLabel.Content = "Force: " + Entity.Body.Force;
                ExternalForceLabel.Content = "External Force: " + Entity.Body.ExternalForces;
                InputVelocityLabel.Content = "Input Velocity: " + Entity.Body.InputVelocity;
                WeightLabel.Content = "Weight: " + Entity.Body.Weight;
                AccelerationLabel.Content = "Acceleration: " + Entity.Body.Acceleration;
                VelocityLabel.Content = "Velocity: " + Entity.Body.Velocity;
                PositionLabel.Content = "Position: " + Entity.Body.Position;
                DragLabel.Content = "Drag: " + Entity.Body.Drag;
                MassLabel.Content = "Mass: " + Entity.Body.Mass;
                DeltaTime.Content = "dt: " + e.Delta + "ms";
                Performance.Content = "Performance: " + Math.Floor(e.Delta * 3600) + " calculations per second";
            });
        }
    }
}
