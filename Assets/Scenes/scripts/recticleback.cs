using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class recticleback : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(0, 0, 0);

        var another = GameObject.Find("nonsee_cube(sky)").GetComponent<InteractiveItem>();

        if (another.image == 1) { transform.localScale = new Vector3(1, 1, 1); }
        if (another.image == 0) { transform.localScale = new Vector3(0, 0, 0); }
    }
}
