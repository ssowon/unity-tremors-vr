using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class type1 : MonoBehaviour
{
    Text typetext;
    int typenum = 1;

    // Start is called before the first frame update
    void Update()
    {
        var other = GameObject.Find("Decibel").GetComponent<Getsound>();
        typenum = other.type;
        if (typenum == 1) { typetext.text = "슬로우스타터"; }
        else if (typenum == 2) { typetext.text = "용두사미형"; }
        else if (typenum == 3) { typetext.text = "자신감 충만형"; }
        else if (typenum == 4) { typetext.text = "초기긴장형"; }
        else if (typenum == 5) { typetext.text = "페이드 아웃형"; }
        else if (typenum == 6) { typetext.text = "실속형"; }
        else if (typenum == 7) { typetext.text = "소심소심형"; }
        else if (typenum == 8) { typetext.text = "집중력 결핍형"; }
        else { typetext.text = "정보전달형"; }
    }

}
