using System;
using BuildByExample;
using NUnit.Framework;

namespace BuildByExampleTests
{
    [TestFixture]
    public class UriByExampleTests
    {
        private readonly string _rootNamespace = typeof(UriByExampleTests).Namespace;

        [Test]
        public void GetUri()
        {
            
            Uri uri = UriByExample.GetXamlUri(_rootNamespace,
                                              () => new JungleGym { SomeInt = 5, SomeDate = DateTime.Parse("10/15/2010") });

            Assert.AreEqual("/JungleGym.xaml?SomeInt=5&SomeDate=10/15/2010 12:00:00 AM", uri.ToString());
        }

        [Test]
        public void GetUriShouldDiscardAnyComplexTypes()
        {
            // It wouldn't be too hard to flatten complex types down like "?SomeInt=5&Monkey_BananasPerMinute=10" 
            Uri uri = UriByExample.GetXamlUri(_rootNamespace,
                                              () => new JungleGym { SomeInt = 5, SomeMonkey = new Monkey { BananasPerMinute = 10 } });

            Assert.AreEqual("/JungleGym.xaml?SomeInt=5", uri.ToString());
        }
    }
}