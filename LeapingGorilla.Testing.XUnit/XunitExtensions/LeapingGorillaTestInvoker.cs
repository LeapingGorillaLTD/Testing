using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Castle.DynamicProxy;
using LeapingGorilla.Testing.XUnit.Composable;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit.XunitExtensions
{
    public class LeapingGorillaTestInvoker : XunitTestInvoker
    {
        public LeapingGorillaTestInvoker(ITest test,
            IMessageBus messageBus,
            Type testClass,
            object[] constructorArguments,
            MethodInfo testMethod,
            object[] testMethodArguments,
            IReadOnlyList<BeforeAfterTestAttribute> beforeAfterAttributes,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource)
            : base(test, messageBus, testClass, constructorArguments, testMethod, testMethodArguments,
                beforeAfterAttributes,
                aggregator,
                cancellationTokenSource)
        {
        }

        internal static readonly ConcurrentDictionary<Type, TestInstanceCacheItem> TestInstanceCache = new ConcurrentDictionary<Type, TestInstanceCacheItem>();
        private static readonly ProxyGenerator Generator = new ProxyGenerator();
        
        protected override object CreateTestClass()
        {
            if (Test.TestCase is LeapingGorillaTestCase lgTestCase)
            {
                if (!TestInstanceCache.ContainsKey(TestClass))
                {
                    var interceptor = new LeapingGorillaAsyncLifetimeInterceptor(lgTestCase.AllTestMethodsInClass);
                    var proxy = Generator.CreateClassProxy(TestClass, interceptor);
                    TestInstanceCache.TryAdd(
                        TestClass,
                        new TestInstanceCacheItem
                        {
                            Interceptor = interceptor,
                            Proxy = proxy
                        });
                }
                
                var cacheItem = TestInstanceCache[TestClass];
                cacheItem.Interceptor.RecordTestMethodInvocation(TestMethod);
                return cacheItem.Proxy;
            }

            return base.CreateTestClass();
        }
    }
}