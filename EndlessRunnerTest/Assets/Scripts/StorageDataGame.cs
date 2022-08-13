using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StorageDataGame
{
    private int _topCoinsScore;

    private void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.TopCoinsScore = _topCoinsScore;
        bf.Serialize(file, data);
        file.Close();
    }

    private void LoadData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            _topCoinsScore = data.TopCoinsScore;
        }
        else Debug.LogError("There is no save data!");
    }

    public int GetTopCoinsScore()
    {
        LoadData();
        return _topCoinsScore;
    }

    public void SetTopCoinsScore(int topCoinsScore)
    {
        _topCoinsScore = topCoinsScore;
        SaveData();
    }
}

[Serializable]
class SaveData
{
    public int TopCoinsScore;
}