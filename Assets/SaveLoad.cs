using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private const string Key = "Key";
    private DataBase _dataBase;

    private void OnEnable() => 
        _dataBase = PlayerPrefs.HasKey(Key)
        ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(Key)) 
        : new DataBase();

    private void OnDisable() => Save();

    public bool ReadTimer() => _dataBase.Timer;
    public int ReadScore() => _dataBase.Score;

    public void SaveTimer(bool currentTimer) => _dataBase.Timer = currentTimer;
    public void SaveScore(int currentScore) => _dataBase.Score = currentScore;

    private void Save()
    {
        PlayerPrefs.SetString(Key, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }
}
