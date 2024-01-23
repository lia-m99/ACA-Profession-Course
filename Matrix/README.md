# Matrix Class

The `Matrix` class is designed to represent a two-dimensional matrix of integers. It provides properties for retrieving the number of rows and columns, and an indexer to access elements in the matrix using row and column indices.

## Properties

### Rows
- **Type:** `int`
- **Description:** Read-only property that returns the number of rows in the matrix.

### Columns
- **Type:** `int`
- **Description:** Read-only property that returns the number of columns in the matrix.

## Indexer

The `Matrix` class implements an indexer that allows you to access elements in the matrix using row and column indices. The indexer ensures proper bounds checking to prevent accessing elements outside the matrix.

```csharp
// Example usage of the indexer
Matrix matrix = new Matrix(3, 4);
int element = matrix[1, 2];
