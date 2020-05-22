using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text uiText;
    public static float time = 0;
    public static int min = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 60)
        {
            min++;
            time -= 60;
        }

        uiText.text = string.Format("{0:D2} : {1:D2}", min, (int)time);

    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("time", time);
        PlayerPrefs.SetInt("min", min);
        PlayerPrefs.Save();
    }
}
