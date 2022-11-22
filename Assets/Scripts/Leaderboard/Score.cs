using System;

[Serializable]
public class Score
{
    public string name;
    public float score;
    public LEVEL level;

    public Score(string name, float score, LEVEL level)
    {
        this.name = name;
        this.score = score;
        this.level = level;
    }
}
