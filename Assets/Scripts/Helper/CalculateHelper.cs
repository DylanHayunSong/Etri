using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculateHelper
{
    public static float Remap (float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

    public static float Min(this List<float> list)
    {
        float result = Mathf.Infinity;

        for(int i = 0; i < list.Count; i++)
        {
            result = Mathf.Min(result, list[i]);
        }

        return result;
    }

    public static float Max(this List<float> list)
    {
        float result = Mathf.NegativeInfinity;

        for(int i = 0; i < list.Count; i++)
        {
            result = Mathf.Max(result, list[i]);
        }

        return result;
    }
}
