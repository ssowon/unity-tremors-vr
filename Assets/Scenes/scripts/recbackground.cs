using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class recbackground: MonoBehaviour
{
    public Image img;

    void Update()
    {
        Color color = img.color;

        var another = GameObject.Find("nonsee_cube(sky)").GetComponent<InteractiveItem>();

        if (another.image == 1) { color.a = 0.5f; }
        if (another.image == 0) { color.a = 0f; }




        img.color = color;
    }
}
