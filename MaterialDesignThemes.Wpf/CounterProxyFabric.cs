using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialDesignThemes.Wpf
{
    public static partial class CounterProxyFabric
    {
        private sealed class CounterProxyBuilder
        {
            private readonly Func<Control, bool> _canBuild;
            private readonly Func<Control, ICounterProxy> _build;

            public CounterProxyBuilder(Func<Control, bool> canBuild, Func<Control, ICounterProxy> build)
            {
                _canBuild = canBuild ?? throw new ArgumentNullException(nameof(canBuild));
                _build = build ?? throw new ArgumentNullException(nameof(build));
            }

            public bool CanBuild(Control control) => _canBuild(control);
            public ICounterProxy Build(Control control) => _build(control);
        }

        private static readonly List<CounterProxyBuilder> Builders = new List<CounterProxyBuilder>();

        static CounterProxyFabric()
        {
            Builders.Add(new CounterProxyBuilder(c => c is TextBox, c => new TextBoxCounterProxy((TextBox)c)));
        }

        public static void RegisterBuilder(Func<Control, bool> canBuild, Func<Control, ICounterProxy> build)
        {
            Builders.Add(new CounterProxyBuilder(canBuild, build));
        }

        public static ICounterProxy Get(Control control)
        {
            return Builders.FirstOrDefault(v => v.CanBuild(control))?.Build(control);
        }
    }
}
