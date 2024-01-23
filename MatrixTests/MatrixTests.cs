namespace MatrixTests
{
    using Matrix;

    public class Tests
    {
        [TestFixture]
        public class MatrixTests
        {
            [Test]
            public void Constructor_InvalidRowsOrColumns_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => new Matrix(0, 3));
                Assert.Throws<ArgumentException>(() => new Matrix(2, 0));
                Assert.Throws<ArgumentException>(() => new Matrix(-1, 5));
            }

            [Test]
            public void RowsAndColumns_Properties_ReturnCorrectValues()
            {
                Matrix matrix = new Matrix(3, 4);

                Assert.That(matrix.Rows, Is.EqualTo(3));
                Assert.That(matrix.Columns, Is.EqualTo(4));
            }

            [Test]
            public void Indexer_GetElement_ReturnsCorrectValue()
            {
                Matrix matrix = new Matrix(2, 2);
                matrix[0, 0] = 1;
                matrix[0, 1] = 2;

                Assert.That(matrix[0, 0], Is.EqualTo(1));
                Assert.That(matrix[0, 1], Is.EqualTo(2));
            }

            [Test]
            public void Indexer_SetElement_ModifiesMatrix()
            {
                Matrix matrix = new Matrix(2, 2);
                matrix[1, 1] = 5;

                Assert.That(matrix[1, 1], Is.EqualTo(5));
            }

            [Test]
            public void Indexer_InvalidIndices_ThrowsIndexOutOfRangeException()
            {
                Matrix matrix = new Matrix(2, 3);

                var subscript = (int i, int j) => matrix[i, j];

                Assert.Throws<IndexOutOfRangeException>(() => subscript(-1, 2));
                Assert.Throws<IndexOutOfRangeException>(() => subscript(1, 3));
                Assert.Throws<IndexOutOfRangeException>(() => subscript(2, 1));
            }
        }
    }
}