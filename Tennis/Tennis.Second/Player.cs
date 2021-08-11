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

        public void TransformPointsToResult()
        {
            Result = Point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => Result
            };
        }

        public string CalculateScoreExceptForty(string score)
        {
            score = Point switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => score
            };
            return score;
        }
    }
}