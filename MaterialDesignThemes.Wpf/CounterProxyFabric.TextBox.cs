using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace MaterialDesignThemes.Wpf
{
    public static partial class CounterProxyFabric
    {
        private sealed class TextBoxCounterProxy : ICounterProxy
        {
            private readonly TextBox _textBox;

            /// <inheritdoc/>
            public string Counter => string.Format("{0}/{1}", (_textBox.Text ?? string.Empty).Length, _textBox.MaxLength);

            /// <inheritdoc/>
            public event PropertyChangedEventHandler PropertyChanged;

            public TextBoxCounterProxy(TextBox textBox)
            {
                _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
                _textBox.TextChanged += TextBoxTextChanged;
            }

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
            {
                OnPropertyChanged(nameof(Counter));
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                _textBox.TextChanged -= TextBoxTextChanged;
            }
        }
    }
}
