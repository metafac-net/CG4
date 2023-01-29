using System;
using System.Collections.Generic;

namespace MetaCode.Generators
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
        public IDisposable NewScope(TemplateScope newScope)
        {
            var oldTop = _scopeStack.Peek();
            var newTop = new TemplateScope(oldTop.Scope.Tokens.SetItems(newScope.Tokens), newScope.Iterators);
            _scopeStack.Push(new EngineScope(scope: newTop));
            return new ScopePopper(this);
        }
    }
}