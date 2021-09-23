using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static Color GetRandomHDRColor(float colorIntensity)
    {
        Color color = new Color();

        float[] colors = new float[3];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Random.Range(0.0f, 1.0f);
        }

        int index = Random.Range(0, 3);
        colors[index] = 0;

        int offset = Random.Range(1, 3);
        colors[(index + offset) % 3] = 1;

        float factor = Mathf.Pow(2, colorIntensity);

        color = new Color(colors[0] * factor, colors[1] * factor, colors[2] * factor);

        return color;
    }

    public static Color GetRandomColor()
    {
        Color color = new Color();

        float[] colors = new float[3];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Random.Range(0.0f, 1.0f);
        }

        int index = Random.Range(0, 3);
        colors[index] = 0;

        int offset = Random.Range(1, 3);
        colors[(index + offset) % 3] = 1;

        color = new Color(colors[0], colors[1], colors[2]);

        return color;
    }
}
