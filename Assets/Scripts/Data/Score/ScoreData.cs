using EventBus;

public class ScoreData 
{
    public int Score;
}

public interface IScoreDataManager : IService
{
    public void AddLineScore();
}

public class ScoreDataManager : IScoreDataManager
{
    private ScoreData _scoreData = new ();

    public void ActivateService()
    {
        _scoreData.Score = 0;
    }

    public void AddLineScore()
    {
        _scoreData.Score += 10;
        EventBus<ScoreChanged>.Raise(new ScoreChanged { score = _scoreData.Score });
    }
}

