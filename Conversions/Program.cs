using Conversions;

class Program
{
    static void Main()
    {
        Coordinate coordinate = new Coordinate(1.5, 2.5);

        // Implicit
        Vector vectorFromCoordinate = coordinate;

        Console.WriteLine("Coordinate to Vector (Implicit Conversion):");
        Console.WriteLine($"Coordinate: ({coordinate.X}, {coordinate.Y})");
        Console.WriteLine($"Vector: ({vectorFromCoordinate.X}, {vectorFromCoordinate.Y})");
        Console.WriteLine();

        Vector vector = new Vector(3.0, 4.0);

        // Explicit
        Coordinate coordinateFromVector = (Coordinate)vector;

        Console.WriteLine("Vector to Coordinate (Explicit Conversion):");
        Console.WriteLine($"Vector: ({vector.X}, {vector.Y})");
        Console.WriteLine($"Coordinate: ({coordinateFromVector.X}, {coordinateFromVector.Y})");
    }
}