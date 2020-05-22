using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leansc : MonoBehaviour
{
    public Text LeanText;
    public float xx;
    public float yy;

    void Update()
    {
        xx = Input.acceleration.x * 100;
        yy = Input.acceleration.y * 100;

        LeanText.text = xx.ToString("N2") + " , " + yy.ToString("N2");

    }
}
