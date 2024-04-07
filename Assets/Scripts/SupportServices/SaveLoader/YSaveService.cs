using YG;

public class YSaveService
{
    public YSaveService()
    {
        //YandexGame.LoadProgress();
    }

    public void SaveRecord(RecordData item)
    {
        YandexGame.savesData.RecordData = item;
        YandexGame.SaveProgress();
    }

    public RecordData LoadRecord() => YandexGame.savesData.RecordData;
}
