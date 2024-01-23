namespace Conversions
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector(Coordinate coordinate)
        {
            return new Vector(coordinate.X, coordinate.Y);
        }
    }
}
