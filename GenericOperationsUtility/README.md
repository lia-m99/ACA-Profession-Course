# Generic Calculation Utility

## Overview

The Generic Calculation Utility project provides a generic interface for various calculations, supporting both numeric and string operations. It includes separate implementations for numeric and string calculations.

## Features

- **ICalculationUtility Interface (Generic):**
  - Generic interface for addition, subtraction, multiplication, division, and quotient/remainder operations.
  - Separate implementations for numeric and string types.

- **Numeric Implementation:**
  - Implementation of ICalculationUtility for numeric operations.

- **String Implementation:**
  - Implementation of ICalculationUtility for string operations.
  - Throws NotSupportedException for operations not commonly used for string type.

## Project Structure

The project is organized into the following components:

- **Interfaces**: Contains the ICalculationUtility generic interface.
- **NumericImplementation**: Implementation of ICalculationUtility for numeric types.
- **StringImplementation**: Implementation of ICalculationUtility for string types.
- **ClientCode**: Example console application demonstrating the usage of the generic calculation utility.

## How to Use

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/GenericCalculationUtility.git
