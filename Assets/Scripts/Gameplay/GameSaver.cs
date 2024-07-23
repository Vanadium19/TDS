using UnityEngine;

public static class GameSaver
{
    private static readonly string _score = "Score";
    private static readonly int _defaultScore = 0;

    public static int Score => PlayerPrefs.GetInt(_score, _defaultScore);

    public static void SaveScore(int score)
    {
        if (Score >= score)
            return;

        PlayerPrefs.SetInt(_score, score);
    }
}