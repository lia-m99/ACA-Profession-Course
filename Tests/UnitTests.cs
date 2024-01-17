namespace CustomContainer.Tests
{
    public class Tests
    {
        [TestFixture]
        public class ConditionBasedCollectionTests
        {
            [Test]
            public void AddCorrectItemTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0) { 2, 4, 6 };

                Assert.That(collection.Count, Is.EqualTo(3));
            }

            [Test]
            public void AddIncorrectItemTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0) { 3, 5, 7 };

                Assert.That(collection.Count, Is.EqualTo(0));
            }

            [Test]
            public void ContainsTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0);
                
                collection.Add(2);

                bool result = collection.Contains(2);
                Assert.IsTrue(result);

                collection.Add(3);
                result = collection.Contains(3);
                Assert.IsFalse(result);
            }

            [Test]
            public void AddRangeTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0);

                collection.AddRange(new[] { 1, 2, 3, 4, 5, 6 });
                CollectionAssert.AreEqual(new[] { 2, 4, 6 }, collection.RowData());

                Assert.Throws<ArgumentNullException>(() => collection.AddRange(null));

                collection.Clear();
                collection.AddRange(new[] { 1, 3, 5 });
                CollectionAssert.IsEmpty(collection.RowData());
            }

            [Test]
            public void EnumeratorTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0);
                collection.AddRange(new[] { 1, 2, 3, 4, 5, 6 });

                var result = new List<int>();
                foreach (var item in collection)
                {
                    result.Add(item);
                }

                CollectionAssert.AreEqual(new[] { 2, 4, 6 }, result);
            }

            [Test]
            public void CopyToTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0);
                collection.AddRange(new[] { 2, 4, 6 });

                var destinationArray1 = new int[5];
                var destinationArray2 = new int[5];
                var destinationArray3 = new int[2];

                collection.CopyTo(destinationArray1, 1);
                CollectionAssert.AreEqual(new[] { 0, 2, 4, 6, 0 }, destinationArray1);

                Assert.Throws<ArgumentNullException>(() => collection.CopyTo(null, 0));
                Assert.Throws<ArgumentOutOfRangeException>(() => collection.CopyTo(destinationArray2, -1));
                Assert.Throws<ArgumentOutOfRangeException>(() => collection.CopyTo(destinationArray2, 6));
                Assert.Throws<ArgumentException>(() => collection.CopyTo(destinationArray3, 0));
            }

            [Test]
            public void RemoveTest()
            {
                var collection = new ConditionBasedCollection<int>(x => x % 2 == 0);
                collection.AddRange(new[] { 2, 4, 6 });

                var result1 = collection.Remove(4);
                var result2 = collection.Remove(3);

                Assert.IsTrue(result1);
                Assert.IsFalse(result2);

                CollectionAssert.AreEqual(new[] { 2, 6 }, collection.RowData());
            }
        }
    }
}