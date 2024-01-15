namespace ConditionBasedCollection
{
    public static class Helper<T>
    {
        public static void HandleAddElement(T item) {
            Console.WriteLine($"Item '{item}' is added.");
        }

        public static void HandleRemoveElement(T item) {
            Console.WriteLine($"Item '{item}' is removed.");
        }
    }
}
