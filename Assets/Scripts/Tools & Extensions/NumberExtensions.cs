using UnityEngine;

public static class NumberExtensions
{
    public static bool InRange(this float value, float min, float max)
    {
        return value >= min && value <= max;
    }

    public static float Precise(this float value, int precision)
    {
        return Mathf.Round(value * precision) / precision;
    }

    public static bool InRange(this int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}