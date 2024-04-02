using EventBus;
using UnityEngine;

public class RecordData : MonoBehaviour
{
    public int Record;
}

public interface IRecordDataManager : IService
{
    public int GetRecord();
    public void DeactivateService();
}

public class RecordDataManager : IRecordDataManager
{
    private RecordData _recordData = new();
    private EventBinding<ScoreChanged> _scoreChanged;
    private const string RecordKey = "RecordKey";

    public void ActivateService()
    {
        _recordData.Record = LoadRecord();
        _scoreChanged = new(CheckRecord);
    }

    public int GetRecord() => _recordData.Record;

    public void DeactivateService()
    {
        _scoreChanged.Remove(CheckRecord);
    }

    private void CheckRecord(ScoreChanged scoreChanged)
    {
        if (_recordData.Record < scoreChanged.score)
            SetRecord(scoreChanged.score);
    }

    private int LoadRecord()
    {
        if (PlayerPrefs.HasKey(RecordKey))
            return PlayerPrefs.GetInt(RecordKey, 0);
        PlayerPrefs.SetInt(RecordKey, 0);
        return 0;
    }
    
    private void SetRecord(int newRecord)
    {
        _recordData.Record = newRecord;
        PlayerPrefs.SetInt(RecordKey, newRecord);
        EventBus<RecordChanged>.Raise(new RecordChanged { record = newRecord });
    }

}
