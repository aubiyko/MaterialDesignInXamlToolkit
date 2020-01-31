using System.Windows;

namespace MaterialDesignThemes.Wpf
{
    /// <summary>
    /// Helper properties for working with text field character counter.
    /// </summary>
    internal static class CharacterCounterAssist
    {
        #region CounterProxy

        internal static readonly DependencyProperty CounterProxyProperty = DependencyProperty.RegisterAttached(
            "CounterProxy",
            typeof(ICounterProxy),
            typeof(CharacterCounterAssist),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        internal static ICounterProxy GetCounterProxy(DependencyObject element)
        {
            return (ICounterProxy)element.GetValue(CounterProxyProperty);
        }

        internal static void SetCounterProxy(DependencyObject element, ICounterProxy value)
        {
            element.SetValue(CounterProxyProperty, value);
        }

        #endregion
    }
}
