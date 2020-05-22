using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class rectext : MonoBehaviour
{
    [SerializeField] private Text Textrec;

    void Update()
    {
        Textrec.text = " ";

        var another = GameObject.Find("nonsee_cube(sky)").GetComponent<InteractiveItem>();

        if (another.image == 1) { Textrec.text = "시선을 바르게 하세요"; }
        if (another.image == 0) {Textrec.text = " ";}

    }
}
