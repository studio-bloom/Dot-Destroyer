using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveMoney(MoneyManager moneyManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/money.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MoneyData data = new MoneyData(moneyManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MoneyData LoadMoney()
    {
        string path = Application.persistentDataPath + "/money.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MoneyData data = formatter.Deserialize(stream) as MoneyData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
