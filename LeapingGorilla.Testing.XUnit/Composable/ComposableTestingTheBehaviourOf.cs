using System;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Composable;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Composable
{
    /// <summary>
    /// Base class for XUnit tests using the Composable BDD test pattern.
    ///
    /// Implementors should override the ComposeTest() method and perform other test setup as with
    /// <see cref="WhenTestingTheBehaviourOf"/> tests.
    /// </summary>
    public abstract class ComposableTestingTheBehaviourOf : ComposableTestingTheBehaviourOfBase, IAsyncLifetime
    {
        private readonly bool _shouldSetup;
        
        /// <summary>
        /// Performs setup for this instance - this will prepare all mocks and request the test composition via the
        /// ComposeTest() abstract method. Following this it will call the [Given] methods (if any) and then call the
        /// [When] methods (if any). On completion the instance will be ready for the [Then] methods defined in the test
        /// composition to be executed.
        /// </summary>
        /// <param name="shouldSetup">
        /// Should we perform the setup step? Pass false to skip setup. If you skip setup you will
        /// need to implement it yourself by calling the <see cref="ComposableTestingTheBehaviourOfBase.SetupAsync">base.SetupAsync()</see>
        /// method.
        /// </param>
        protected ComposableTestingTheBehaviourOf(bool shouldSetup = true)
        {
            _shouldSetup = shouldSetup;
        }
        
        public virtual async Task InitializeAsync()
        {
            if (_shouldSetup)
            {
                await SetupAsync();
            }
        }
        
        public virtual Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}