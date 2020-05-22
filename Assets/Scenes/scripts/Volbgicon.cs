using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volbgicon : MonoBehaviour
{
    void Update()
    {
        var other = GameObject.Find("Vol").GetComponent<othersound>();
        if (other.loudness < 20 && other.loudness > 5) { transform.localScale = new Vector3(1, 1, 1); }
        else if (other.loudness > 80) { transform.localScale = new Vector3(1, 1, 1); }
        else { transform.localScale = new Vector3(0, 0, 0); }
    }
}
