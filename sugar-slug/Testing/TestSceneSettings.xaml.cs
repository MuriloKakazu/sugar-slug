using SugarSlug.Engine.Environments;
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

namespace SugarSlug.Testing
{
    /// <summary>
    /// Interaction logic for TestSceneSettings.xaml
    /// </summary>
    public partial class TestSceneSettings : UserControl {
        public TestSceneSettings() {
            InitializeComponent();
        }

        private void GravityValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (DesignerProperties.GetIsInDesignMode(this)) {
                return;
            }

            Game.Scene.Environment.Gravity.Y = (float)e.NewValue;
        }

        private void DensityValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (DesignerProperties.GetIsInDesignMode(this)) {
                return;
            }

            var currentGravity = Game.Scene.Environment.Gravity;
            Game.Scene.Environment = new CustomEnvironment(currentGravity, (float)e.NewValue);
        }
    }
}
