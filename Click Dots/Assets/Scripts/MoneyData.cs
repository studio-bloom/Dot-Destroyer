﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyData
{
    public int money;

    public MoneyData (MoneyManager moneyManager)
    {
        money = moneyManager.money;
    }
}
