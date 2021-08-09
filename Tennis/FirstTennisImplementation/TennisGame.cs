using System;
using System.Collections.Generic;
using Tennis.Contract;

namespace Tennis.First
{
    public class TennisGame : ITennisGame
    {
        private const string DEUCE = "Deuce";
        private int _firstPlayerScore;
        private int _secondPlayerScore;
        private string _player1Name;
        private string _player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _firstPlayerScore++;
            else
                _secondPlayerScore++;
        }

        public string GetScore()
        {
            var score = string.Empty;
            if (_firstPlayerScore == _secondPlayerScore)
            {
                score = GetEqualityScore();
            }
            else if (_firstPlayerScore >= 4 || _secondPlayerScore >= 4)
            {
                score = GetAdvantageScore();
            }
            else
            {
                score = GetNormalScore(score);
            }

            return score;
        }

        private string GetNormalScore(string score)
        {
            var possibleScores = new Dictionary<int, string>()
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"}
            };

            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1)
                {
                    tempScore = _firstPlayerScore;
                }
                else
                {
                    score += "-";
                    tempScore = _secondPlayerScore;
                }

                possibleScores.TryGetValue(tempScore, out var parsedScore);
                score += parsedScore;
            }

            return score;
        }

        private string GetAdvantageScore()
        {
            var advantageScores = new Dictionary<int, string>()
            {
                {1, "Advantage player1"},
                {-1, "Advantage player2"}
            };

            var minusResult = _firstPlayerScore - _secondPlayerScore;
            return advantageScores.GetValueOrDefault(minusResult, minusResult >= 2 ? "Win for player1" : "Win for player2");
        }

        private string GetEqualityScore()
        {
            var possibleEqualityScores = new Dictionary<int, string>()
            {
                {0, "Love-All"},
                {1, "Fifteen-All"},
                {2, "Thirty-All"}
            };

            return possibleEqualityScores.GetValueOrDefault(_firstPlayerScore, DEUCE);
        }
    }
}