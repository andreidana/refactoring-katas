namespace Tennis.Second
{
    public class Player
    {
        public string Name { get; set; }
        public string Result { get; set; }
        public int Point { get; set; }

        public Player(string name)
        {
            Name = name;
            Result = string.Empty;
            Point = 0;
        }
    }
}