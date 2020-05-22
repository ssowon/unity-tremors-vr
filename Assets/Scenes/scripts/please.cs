using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class please : MonoBehaviour
{
    Text TypeText;
    int typenum = 1;
    // Start is called before the first frame update
    void Start()
    {
//        var other = GameObject.Find("Decibel").GetComponent<Getsound>();
//        typenum = other.type;
        TypeText.text = typenum.ToString();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
