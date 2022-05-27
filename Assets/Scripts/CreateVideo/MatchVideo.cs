using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public static class MatchVideo
{
    private static List<int> parametrs;
    private static double timecreatevideo;

    public static double GetTime(this double time,int bed, int comp)
    {
        parametrs = new(2);
        parametrs.Add(bed);
        parametrs.Add(comp);
        timecreatevideo = time;
        return MatchVid();
    }

    public static int GetSubsrib(this int subsc, int cam, int chrom)
    {
        parametrs = new();
        parametrs.Add(cam);
        parametrs.Add(chrom);
        int ss = MatchSub(subsc)+10;
        return ss;
    }

    public static int GetMoney(this int money, int sub)
    {
        money += (sub % 60) * 2;
        return money;
    }

    private static int MatchSub(int subs)
    {
        int ii = subs;
        for (int i = 0; i < parametrs.Count; i++)
        {
            ii += subs * parametrs[i] % 30;
            Debug.Log("Subb+"+subs);
        }
        return ii;
    }
    private static double MatchVid()
    {
        double time = timecreatevideo;
        for (int i = 0; i < parametrs.Count; i++)
        {
            if (parametrs[i] != 0)
            {
                var coof = parametrs[i] % 10;
                time -= coof;
            }
        }

        return time;
    }
}
