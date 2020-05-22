using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class recticleback1 : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(0, 0, 0);

        var nother = GameObject.Find("nonsee_cube(base)").GetComponent<InteractiveItem1>();

        if (nother.image == 1) { transform.localScale = new Vector3(1, 1, 1); }
        if (nother.image == 0) { transform.localScale = new Vector3(0, 0, 0); }
    }
}
