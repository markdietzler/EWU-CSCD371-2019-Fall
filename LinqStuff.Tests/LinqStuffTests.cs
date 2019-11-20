using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace LinqStuff.Tests
{
    [TestClass]
    public class LinqStuffTests
    {
        [TestMethod]
        public void GetAllMembersOnList()
        {
            IEnumerable<MemberInfo> members;
            IEnumerable<(string, char)> query = GetData(typeof(Enumerable).GetMembers());
            query = query.Where(item => true);



            //IEnumerable<string> names = query.Select(item => item.Name);
            //IEnumerable<(string, char)> namesWithFirstLetter =
            //    members.Select(item => (item.Name, item.Name[0]));
            //int count = members.Count();
            //members.First(item => item.Name == "Count");


        }
        int InvocationCount { get; set; }

        private IEnumerable<(string, char)> GetData(IEnumerable<MemberInfo> members)
        {
            InvocationCount = 0;
            members = typeof(Enumerable).GetMembers();
            IEnumerable<(string, char)> result = members.Where(item =>
            {
                InvocationCount++;
                return item.Name.StartsWith("C");
            })
                .Where(item =>
                {
                    InvocationCount++;
                    return item.Name.Length % 2 == 0;
                })
                .Select(item => (item.Name, item.Name[0]));
            
            return result;
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestIterationCount()
        {
            // If you don't iterate over the query, the invocation count won't increase.
            IEnumerable<(string, char)> query = GetData(typeof(Enumerable).GetMembers());
            Assert.AreEqual<int>(0, InvocationCount);


            // Foreach triggers iterating over all the items.
            foreach (string name in query.Select(item => item.Item1))
            {
                TestContext.WriteLine(name);
            }
            Assert.AreEqual<int>(192, InvocationCount);

            // Count iterates over all the items.
            Assert.AreEqual<int>(4, query.Count());
            Assert.AreEqual<int>(192*2, InvocationCount);

            // Creating a new list collection (cache) iterats over all the items.
            List<(string, char)> data = query.ToList();
            Assert.AreEqual<int>(192*3, InvocationCount);

            // Iterating over the list (cache) no longer occurs iterating the query.
            Assert.AreEqual<int>(4, data.Count());
            Assert.AreEqual<int>(192*3, InvocationCount);
        }

        [TestMethod]
        public void VerifyMemberCountOnEnumerable()
        {
            var query = GetData(typeof(Enumerable).GetMembers());
            Assert.AreEqual<int>(4, query.Count());
        }
    }
}
