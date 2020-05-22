using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class rectext1 : MonoBehaviour
{
    [SerializeField] private Text Textrec;

    void Update()
    {
        Textrec.text = " ";

        var nother = GameObject.Find("nonsee_cube(base)").GetComponent<InteractiveItem1>();

        if (nother.image == 1) { Textrec.text = "시선을 바르게 하세요"; }
        if (nother.image == 0) {Textrec.text = " ";}

    }
}
