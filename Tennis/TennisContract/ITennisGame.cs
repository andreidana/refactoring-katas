namespace Tennis.Contract
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}

