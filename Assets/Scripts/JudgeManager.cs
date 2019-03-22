﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JudgeType
{
    IGNORE,
    POOR,
    BAD,
    GOOD,
    GREAT,
    PGREAT
}

public class JudgeManager {

    private static JudgeManager inst = null;
    public static JudgeManager instance
    {
        get
        {
            if (inst == null) inst = new JudgeManager();
            return inst;
        }
        private set { inst = value; }
    }

	public double DAbs(double d) => (d >= 0) ? d : -d;

    public JudgeType Judge(Note n, double currentTime)
    {
        double diff = DAbs(n.Timing - currentTime) * 1000;
        //Debug.Log($"note : {n.Timing}, currentTime : {currentTime}");
        if (n.Timing > currentTime && diff >= 220.0) return JudgeType.IGNORE;

        if (diff < 21.0)
            return JudgeType.PGREAT;
        else if (diff < 60.0)
            return JudgeType.GREAT;
        else if (diff < 150.0)
            return JudgeType.GOOD;
        else if (diff < 220.0)
            return JudgeType.BAD;
        else
            return JudgeType.POOR;

    }
}