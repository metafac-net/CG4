using MetaFac.CG4.TextProcessing;
using MetaFac.Platform;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG4.Generators
{
    public abstract class GeneratorBase
    {
        protected readonly TemplateEngine _engine = new TemplateEngine();
        private readonly List<string> _output = new List<string>();

        private readonly string _shortName;
        public string ShortName => _shortName;

        protected GeneratorBase(string shortName)
        {
            _shortName = shortName;
        }

        protected void Emit(string encodedOutput)
        {
            if (!_engine.Current.Ignored)
            {
                string templateLine = encodedOutput;
                string? replacedLine = _engine.Current.ReplaceTokens(templateLine);
                _output.Add(replacedLine ?? "");
            }
        }

        protected void Define(string name, string value)
        {
            _engine.Current.SetToken(name, value);
        }

        protected IDisposable Ignored()
        {
            return _engine.Ignore();
        }

        protected IDisposable NewScope(TemplateScope newScope)
        {
            return _engine.NewScope(newScope);
        }

        protected void DumpTokens()
        {
            _output.Add("//dump: ---------- begin ----------");
            foreach (var kvp in _engine.Current.Scope.Tokens)
            {
                _output.Add($"//dump: {kvp.Key}='{kvp.Value}'");
            }
            _output.Add("//dump: ----------- end -----------");
        }

        protected abstract void OnGenerate(TemplateScope outerScope);

        /// <summary>
        /// Generates output using the supplied metadata and options.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// metadata
        /// or
        /// options
        /// </exception>
        public IEnumerable<string> Generate(ILogger logger, ITimeOfDayClock clock, TemplateScope metadata, GeneratorOptions? usersOptions)
        {
            if (metadata is null) throw new ArgumentNullException(nameof(metadata));

            using var etc = new NotEncryptedTextCache();
            using (NewScope(metadata))
            {
                OnGenerate(metadata);
                foreach (var line in _output)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// Generates output using the supplied metadata and default options.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        public IEnumerable<string> Generate(ILogger logger, ITimeOfDayClock clock, TemplateScope metadata)
        {
            return Generate(logger, clock, metadata, null);
        }

    }
}