# Employee Management System

The Employee Management System is a simple C# project that demonstrates basic functionalities of an employee management application. It includes features such as creating employees with a parameterized constructor, using reflection for type information, and implementing custom attribute validation for salary range.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)

## Features

- **Employee Class:**
  - Definition of the `Employee` class with attributes such as Id, Name, and Salary.
  - Parameterized constructor for creating employee instances.
  - DisplayInfo method to print employee information.

- **Reflection:**
  - Use of reflection to dynamically inspect and display type information of the `Employee` class.
  - Reflection for checking the presence of a custom attribute on the `Salary` property.

- **Custom Attribute:**
  - Implementation of a custom attribute (`SalaryValidationAttribute`) for validating the salary property.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/EmployeeManagementSystem.git
