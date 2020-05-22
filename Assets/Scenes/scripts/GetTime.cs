using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    Text timeText;
    float time = 0;
    int min = 0;
    void Start()
    {
        timeText = GetComponent<Text>();
        time = PlayerPrefs.GetFloat("time");
        min = PlayerPrefs.GetInt("min");
        timeText.text = string.Format("{0:D2} : {1:D2}", min, (int)time);
    }
}
