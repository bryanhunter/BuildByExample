using System;
using System.Collections.Generic;
using BuildByExample;
using NUnit.Framework;

namespace BuildByExampleTests
{
    [TestFixture]
    public class DictionaryByExampleTests
    {
        [Test]
        public void TryTypeWithGuidVariableArg()
        {
            Guid theArg = Guid.NewGuid();
            Dictionary<string, object> results = DictionaryByExample.Build(() => new JungleGym { SomeGuid = theArg });

            Assert.IsNotNull(results);
            Assert.IsTrue(results.ContainsKey("SomeGuid"));
            Assert.AreEqual(theArg, results["SomeGuid"]);
        }

        [Test]
        public void TryTypeWithIntArg()
        {
            Dictionary<string, object> results = DictionaryByExample.Build(() => new JungleGym { SomeInt = 42 });

            Assert.IsNotNull(results);
            Assert.IsTrue(results.ContainsKey("SomeInt"));
            Assert.AreEqual(42, results["SomeInt"]);
        }

        [Test]
        public void TryTypeWithIntVariableArg()
        {
            const int theInt = 42;
            Dictionary<string, object> results = DictionaryByExample.Build(() => new JungleGym { SomeInt = theInt });

            Assert.IsNotNull(results);
            Assert.IsTrue(results.ContainsKey("SomeInt"));
            Assert.AreEqual(42, results["SomeInt"]);
        }

        [Test]
        public void TryTypeWithMonkeyArg()
        {
            Dictionary<string, object> results =
                DictionaryByExample.Build(
                    () => new JungleGym { SomeMonkey = new Monkey { BananasPerMinute = 4, Name = "Gustav" } });

            Assert.IsNotNull(results);
            Assert.IsTrue(results.ContainsKey("SomeMonkey"));
            var actual = (Monkey)results["SomeMonkey"];

            Assert.AreEqual(4, actual.BananasPerMinute);
            Assert.AreEqual("Gustav", actual.Name);
        }

        [Test]
        public void TryTypeWithStringArg()
        {
            Dictionary<string, object> results = DictionaryByExample.Build(() => new JungleGym { SomeString = "Hello" });

            Assert.IsNotNull(results);
            Assert.IsTrue(results.ContainsKey("SomeString"));
            Assert.AreEqual("Hello", results["SomeString"]);
        }
    }
}