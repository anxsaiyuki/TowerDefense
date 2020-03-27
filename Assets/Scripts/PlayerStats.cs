using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // All player information ex (Lives, Currency)

    public static int Money;
    public int startMoney;

    public static int Lives;
    public int startLives;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
