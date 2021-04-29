using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebFramework
{
    public class AssertUITimeout
    {
        private const double defaultTimeoutInSeconds = 20;
        public static Browser Browser { get; set; }

        public static void IsTrue(Func<bool> actual, double timeoutInSeconds = defaultTimeoutInSeconds)
        {
            var result = WaitForCondition(() => { return actual() == true; }, timeoutInSeconds);

            if (!result)
            {
                Assert.Fail("Condition was not true");
            }
        }

        public static void IsTrue(Func<bool> actual, string assertFailureMessage, double timeoutInSeconds = defaultTimeoutInSeconds)
        {
            var result = WaitForCondition(actual, timeoutInSeconds);

            if (!result)
            {
                Assert.Fail(assertFailureMessage);
            }
        }

        public static void IsTrue(Func<bool> actual, Func<string> message, double timeoutInSeconds = defaultTimeoutInSeconds)
        {
            var result = WaitForCondition(actual, timeoutInSeconds);

            if (!result)
            {
                Assert.Fail(message());
            }
        }

        public static void IsFalse(Func<bool> actual, string assertFailureMessage, double timeoutInSeconds = defaultTimeoutInSeconds)
        {
            var result = WaitForCondition(() => { return actual() == false; }, timeoutInSeconds);

            if (!result)
            {
                Assert.Fail(assertFailureMessage);
            }
        }

        public static void IsFalse(Func<bool> actual, Func<string> message, double timeoutInSeconds = defaultTimeoutInSeconds)
        {
            var result = WaitForCondition(() => { return actual() == false; }, timeoutInSeconds);

            if (!result)
            {
                Assert.Fail(message());
            }
        }

        public static bool WaitForCondition(Func<bool> expectedConditionFunc, double timeoutSeconds = defaultTimeoutInSeconds, double pollingIntervalSeconds = 0.5)
        {
            var timeout = TimeSpan.FromSeconds(timeoutSeconds);
            var pollingInterval = TimeSpan.FromSeconds(pollingIntervalSeconds);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                try
                {
                    if (expectedConditionFunc())
                    {
                        stopwatch.Stop();
                        return true;
                    }

                }
                catch (Exception)
                {
                    if (stopwatch.Elapsed.Add(pollingInterval) >= timeout)
                    {
                        stopwatch.Stop();
                        throw;
                    }
                }

                Task wait = Task.Delay((int)pollingInterval.TotalMilliseconds);
                wait.Wait();
            } while (stopwatch.Elapsed < timeout);

            stopwatch.Stop();
            return false;
        }
    }
}
