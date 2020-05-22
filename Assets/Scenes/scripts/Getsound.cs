using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getsound : MonoBehaviour
{
    Text SoundText;
    int decibelCount = 0;
    int listcount;
    public int type=1;
    float avg, avg1, avg2, avg3;
    private List<int> decibel = new List<int>();

    void Start()
    {
        SoundText = GetComponent<Text>();
        avg = PlayerPrefs.GetFloat("avg");
        avg1 = PlayerPrefs.GetFloat("avg1");
        avg2 = PlayerPrefs.GetFloat("avg2");
        avg3 = PlayerPrefs.GetFloat("avg3");
        SoundText.text = avg.ToString("N1")+"dB";

        if (avg1 > 30 && avg2 > 30 && avg3 > 30)
        {
            if (avg1 < avg3) { type = 1; }
            else if (avg1 > avg3) { type = 2; }
            else { type = 3; }
        }
        else if (avg1 > 30 && avg2 > 30)
        {
            type = 5;
        }
        else if (avg2 > 30)
        {
            type = 6;
        }
        else
        {
            if (avg3 > avg1 && avg3 > avg2) { type = 4; }
            else if (avg2 > avg1 && avg2 > avg3) { type = 9; }
            else if (avg1 > 3) { type = 8; }
            else { type = 7; }
        }
    }
}
