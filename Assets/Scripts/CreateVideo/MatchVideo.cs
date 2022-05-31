using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        money += sub % 40;
        return money;
    }

    public static float GetTime(this float time, int comp)
    {
        if (time <= 300)
        {
            time += 30;
        }

        time -= comp % 40;
        return time;
    }
}
