using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgoundvol : MonoBehaviour
{
    public Image img;

    // Update is called once per frame
    void Update()
    {
        Color color = img.color;

        var other = GameObject.Find("Vol").GetComponent<othersound>();

        if (other.loudness < 20 && other.loudness > 5) { color.a = 0.5f; }
        else if (other.loudness > 80) { color.a = 0f; }
        else { color.a = 0f; }

        

    
        img.color = color;
    }
}
