using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG4.Generators
{
    public class TemplateEngine
    {
        private readonly Stack<EngineScope> _scopeStack = new Stack<EngineScope>();
        public EngineScope Current => _scopeStack.Peek();
        internal void PopScope()
        {
            _scopeStack.Pop();
        }
        public TemplateEngine()
        {
            _scopeStack.Push(EngineScope.Default);
        }
        public IDisposable Ignore()
        {
            _scopeStack.Push(new EngineScope(ignored: true));
            return new ScopePopper(this);
        }
        public IDisposable NewScope(IEnumerable<KeyValuePair<string, string>> tokens)
        {
            var oldTop = _scopeStack.Peek();
            var newTop = new TemplateScope(oldTop.Scope.Tokens.SetItems(tokens));
            _scopeStack.Push(new EngineScope(scope: newTop));
            return new ScopePopper(this);
        }
    }
}