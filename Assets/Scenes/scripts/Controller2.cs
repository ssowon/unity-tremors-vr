using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller2 : MonoBehaviour
{

    public GameObject tttt;
    string filenum = "";
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            var other = GameObject.Find("Decibel").GetComponent<Getsound>();
            filenum = other.type.ToString();
            tttt.transform.localScale = new Vector3(1, 1, 1);
            tttt.GetComponent<RawImage>().texture = Resources.Load("typeimage/슬라이드"+filenum,typeof(Texture)) as Texture;
        }
    }
}
