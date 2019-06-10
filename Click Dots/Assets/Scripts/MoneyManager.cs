using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] Text moneyText;
    public int money = 0;

    private void Start()
    {
        int numOfManagers = FindObjectsOfType<MoneyManager>().Length;
        if (numOfManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        string path = Application.persistentDataPath + "/money.txt";
        if (File.Exists(path))
        {
            money = SaveSystem.LoadMoney().money;
        }
        else
        {
            SaveSystem.SaveMoney(this);
        }
    }

    private void Update()
    {
        FindObjectOfType<DummyMoneyScript>().money = money;
    }

    public void AddMoney(int points)
    {
        int moneyToAdd = points / 10;
        money += moneyToAdd;
        SaveSystem.SaveMoney(this);
    }
}
