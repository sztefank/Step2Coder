namespace ConsoleApp2
{
    internal class Item
    {
        public int value;

        public string name;
        public string type;
        public string slot;

        public Item(string name, int value, string type, string slot)
        {
            this.name = name;
            this.value = value;
            this.type = type;
            this.slot = slot;
        }
    }
}
