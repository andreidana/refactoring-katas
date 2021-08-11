using Tennis.Contract;

namespace Tennis.Second
{
    public class TennisGame : ITennisGame
    {
        private Player playerOne;
        private Player playerTwo;

        public TennisGame(string player1Name, string player2Name)
        {
            playerOne = new Player(player1Name);
            playerTwo = new Player(player2Name);
            }

        public string GetScore()
        {
            var score = "";
            if (playerOne.Point == playerTwo.Point && playerOne.Point < 3)
            {
                score = playerOne.CalculateScoreExceptForty(score);
                score += "-All";
            }
            if (playerOne.Point == playerTwo.Point && playerOne.Point > 2)
                score = "Deuce";

            score = GetScoreWhenLeadingToZero(playerOne, playerTwo, score);
            score = GetScoreWhenLeadingToZero(playerTwo, playerOne, score);

            if (playerOne.Point > playerTwo.Point && playerOne.Point < 4)
            {
                playerOne.TransformPointsToResult();
                playerTwo.TransformPointsToResult();

                score = playerOne.Result + "-" + playerTwo.Result;
            }
            if (playerTwo.Point > playerOne.Point && playerTwo.Point < 4)
            {
                playerTwo.TransformPointsToResult();
                playerOne.TransformPointsToResult();

                score = playerOne.Result + "-" + playerTwo.Result;
            }

            if (playerOne.Point > playerTwo.Point && playerTwo.Point >= 3)
            {
                score = "Advantage player1";
            }

            if (playerTwo.Point > playerOne.Point && playerOne.Point >= 3)
            {
                score = "Advantage player2";
            }

            if (playerOne.Point >= 4 && playerTwo.Point >= 0 && (playerOne.Point - playerTwo.Point) >= 2)
            {
                score = "Win for player1";
            }
            if (playerTwo.Point >= 4 && playerOne.Point >= 0 && (playerTwo.Point - playerOne.Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private string GetScoreWhenLeadingToZero(Player player1, Player player2, string score)
        {
            if (player2.Point > 0 && player1.Point == 0)
            {
                player2.TransformPointsToResult();
                player1.Result = "Love";
                score = player1.Result + "-" + player2.Result;
            }

            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            playerOne.Point++;
        }

        private void P2Score()
        {
            playerTwo.Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

