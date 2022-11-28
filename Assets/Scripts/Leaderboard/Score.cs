using System;

[Serializable]
public class Score
{
    public string name;
    public string uuid;
    public float score;
    public LEVEL level;

    public Score(string name, string uuid, float score, LEVEL level)
    {
        this.name = name;
        this.uuid = uuid;
        this.score = score;
        this.level = level;
    }
}
