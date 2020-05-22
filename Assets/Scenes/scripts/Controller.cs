using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject pptt;
    public int num = 1;
    string pptnum = "";
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            SceneManager.LoadScene("feedbackscene");
            GameObject.Find("Vol").SendMessage("SaveTime");
            GameObject.Find("Time").SendMessage("SaveTime");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            num += 1;
            pptnum = num.ToString();
            if (num < 12)
            {
                pptt.GetComponent<RawImage>().texture = Resources.Load("pptimage/슬라이드"+ pptnum, typeof(Texture)) as Texture;
            }else
            {
                num = 1;
                pptt.GetComponent<RawImage>().texture = Resources.Load("pptimage/슬라이드1", typeof(Texture)) as Texture;
            }

        }



    }

}
