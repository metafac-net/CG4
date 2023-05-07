using System;

namespace MetaFac.CG4.Generators
{
    internal class ScopePopper : IDisposable
    {
        private readonly TemplateEngine _engine;

        public ScopePopper(TemplateEngine engine)
        {
            _engine = engine;
        }
        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _engine.PopScope();
        }
    }
}