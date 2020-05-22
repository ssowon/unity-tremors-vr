using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class recbackground1: MonoBehaviour
{
    public Image img;

    void Update()
    {
        Color color = img.color;

        var nother = GameObject.Find("nonsee_cube(base)").GetComponent<InteractiveItem1>();

        if (nother.image == 1) { color.a = 0.5f; }
        if (nother.image == 0) { color.a = 0f; }




        img.color = color;
    }
}
