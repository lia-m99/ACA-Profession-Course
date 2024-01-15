# ConditionBasedCollection

## Overview

`ConditionBasedCollection` is a C# generic collection that allows you to create a collection with a specified condition. It filters elements based on the given condition, allowing you to add items that match the condition. This collection provides events for tracking when elements are added or removed, and unit tests showcase various usages.

## Features

- **Filtering:** The collection only accepts items that satisfy the specified condition.
- **Event Handling:** `ElementAdded` and `ElementRemoved` events are available for tracking changes in the collection.
- **Usages:** The unit tests demonstrate how to use the collection in various scenarios.

## Usage

1. **Create a ConditionBasedCollection:**
   ```csharp
   var conditionCollection = new ConditionBasedCollection<int>(x => x % 2 == 0);

2. **Add Elements:**
   ```csharp
   conditionCollection.ElementAdded += item => Console.WriteLine($"Item '{item}' is added.");
   conditionCollection.Add(2); // Adds 2 to the collection
3. **Remove Elements:**
   ```csharp
   conditionCollection.ElementRemoved += item => Console.WriteLine($"Item '{item}' is removed.");
   conditionCollection.Remove(2); // Removes 2 from the collection
4. **Iterate Over Elements:**
   ```csharp
   foreach (var item in conditionCollection)
   {
      Console.WriteLine($"Item: {item}");
   }

Unit Tests
Unit tests are provided to showcase the functionalities and usages of ConditionBasedCollection.
These tests cover scenarios such as adding, removing, and iterating over elements, ensuring the filtering condition is applied.
