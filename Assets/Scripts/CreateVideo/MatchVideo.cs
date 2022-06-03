using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public static class MatchVideo
{

    public static int GetSubsrib(this int subsc, int cam, int chrom)
    {
        subsc += (cam + chrom)%120;
        return subsc+1;
    }

    public static int GetMoney(this int money, int sub)
    {
        money += sub % 10;
        return money;
    }

    public static float GetTime(this float time, int comp)
    {
        if (time <= 300)
        {
            time += 30;
        }

        time -= comp % 350;
        return time;
    }

    public static int GetUpdate(this int value, int stadia)
    {
        value += (stadia * 15) % 70;
        return value;
    }

    public static int GetToptem(this int val)
    {
        val = Random.Range(0, 4);
        return val;
    }
}
