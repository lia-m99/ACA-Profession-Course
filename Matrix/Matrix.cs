namespace Matrix
{
    using System;

    public class Matrix
    {
        private int[,] data;

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Rows and columns must be greater than zero.");
            }

            Rows = rows;
            Columns = columns;
            data = new int[Rows, Columns];
        }

        public int Rows { get; }

        public int Columns { get; }

        public int this[int row, int column]
        {
            get
            {
                ValidateIndices(row, column);
                return data[row, column];
            }
            set
            {
                ValidateIndices(row, column);
                data[row, column] = value;
            }
        }

        private void ValidateIndices(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new IndexOutOfRangeException("Invalid row or column index.");
            }
        }
    }

}
