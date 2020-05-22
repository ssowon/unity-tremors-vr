using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyerandom : MonoBehaviour
{
    Text EyeText;
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        EyeText = GetComponent<Text>();
        a = Random.Range(30, 70);
        EyeText.text = a.ToString("N1")+"%";
    }

}
