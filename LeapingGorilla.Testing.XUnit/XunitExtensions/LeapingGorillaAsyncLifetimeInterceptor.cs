/*    
   Copyright 2014-2024 Leaping Gorilla LTD

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.XunitExtensions
{
    /// <summary>
    /// Used in conjunction with Castle dynamic proxies to control calls to the IAsyncLifetime
    /// members. xUnit calls these methods before and after running each test but for LG tests
    /// we have overriden the 'new class instance per test' behaviour. This interceptor ensures
    /// that InitializeAsync/DisposeAsync are called only one time per test class. It also removes
    /// the cached test class instance from the cache after disposing as it shouldn't be required
    /// again.
    /// </summary>
    internal class LeapingGorillaAsyncLifetimeInterceptor : IInterceptor
    {
        private bool _alreadyInitialized = false;
        private readonly List<MethodInfo> _expectedTestMethods;

        public LeapingGorillaAsyncLifetimeInterceptor(IEnumerable<MethodInfo> expectedTestMethods)
        {
            _expectedTestMethods = new List<MethodInfo>(expectedTestMethods);
        }
        
        public void Intercept(IInvocation invocation)
        {
            switch (invocation.Method.Name)
            {
                case nameof(IAsyncLifetime.InitializeAsync):
                    InitializeIntercepted(invocation);
                    break;
                case nameof(IAsyncLifetime.DisposeAsync):
                    DisposeAsyncIntercepted(invocation);
                    break;
                default:
                    invocation.Proceed();
                    break;
            }
        }

        public void RecordTestMethodInvocation(MethodInfo testMethod)
        {
            lock (_expectedTestMethods)
            {
                _expectedTestMethods.Remove(testMethod);
            }
        }

        private void InitializeIntercepted(IInvocation invocation)
        {
            // Prevents multiple initialization. By default xUnit creates a class instance per test
            // case. We're now returning the same instance for multiple test cases but xUnit will
            // still call InitializeAsync and DisposeAsync for every test.
            if (_alreadyInitialized)
            {
                invocation.ReturnValue = Task.CompletedTask;
            }
            else
            {
                _alreadyInitialized = true;
                invocation.Proceed();
            }
        }
        
        private void DisposeAsyncIntercepted(IInvocation invocation)
        {
            int expectedTestMethodCount;
            lock (_expectedTestMethods)
            {
                expectedTestMethodCount = _expectedTestMethods.Count;
            }
            
            if (expectedTestMethodCount == 0)
            {
                invocation.Proceed();
                
                // Remove test class instance from the cache as no more invocations are expected
                LeapingGorillaTestInvoker.TestInstanceCache.TryRemove(invocation.Proxy.GetType().BaseType, out _);
            }
            else
            {
                invocation.ReturnValue = Task.CompletedTask;
            }
        }
    }
}