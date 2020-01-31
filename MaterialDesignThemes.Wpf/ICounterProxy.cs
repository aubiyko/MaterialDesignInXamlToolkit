using System;
using System.ComponentModel;

namespace MaterialDesignThemes.Wpf
{
    /// <summary>
    /// This interface is the adapter to get character counter text value from UI control (<see cref="System.Windows.Controls.Primitives.TextBoxBase"/>d).
    /// <para/>
    /// You should implement this interface in order to support counter for your own control.
    /// </summary>
    public interface ICounterProxy : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Gets character counter as final text value.
        /// </summary>
        string Counter { get; }
    }
}
