using System.Windows;
using System.Windows.Input;

namespace SugarSlug.Engine.Input {
    public static class Input {
        public static float Get(InputType type) {
            float output = 0;
            Application.Current.Dispatcher.Invoke(delegate {
                if (type == InputType.Horizontal) {
                    if (Keyboard.IsKeyDown(Key.A)) {
                        output += -1;
                    }
                    if (Keyboard.IsKeyDown(Key.D)) {
                        output += 1;
                    }
                } else if (type == InputType.Vertical) {
                    if (Keyboard.IsKeyDown(Key.W)) {
                        output += 1;
                    }
                } else if (type == InputType.Fire) {
                    if (Mouse.LeftButton == MouseButtonState.Pressed) {
                        output = 1;
                    }
                } else if (type == InputType.Sprint) {
                    if (Keyboard.IsKeyDown(Key.LeftShift)) {
                        output = 1;
                    }
                } else if (type == InputType.Reload) {
                    if (Keyboard.IsKeyDown(Key.R)) {
                        output = 1;
                    }
                } else if (type == InputType.Jump) {
                    if (Keyboard.IsKeyDown(Key.Space)) {
                        output = 1;
                    }
                }
            });
            return output;
        }
    }
}
