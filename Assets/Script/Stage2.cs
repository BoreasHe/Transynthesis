﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : MonoBehaviour {
    bool started = false;
    public SpriteRenderer sr;

    //stage2
    GameObject sunLight;
    // Use this for initialization
    void Start () {
        sunLight = GameObject.Find("Solor");
        sunLight.SetActive(false);
    }

    public void CallIE()
    {
        StartCoroutine("ChangOfLight");
    }

    IEnumerator ChangOfLight()
    {
        if (started == false)
        {
            started = true;
            sunLight.SetActive(true);
            Color colorNg = sunLight.GetComponent<Image>().color;
            float changeA = 0.01f;
            while (true)
            {
              //  Debug.Log("colorNg.a " + colorNg.a);
                if (colorNg.a >= 0.9)
                    changeA = -0.05f;
                else if (colorNg.a <= 0.6)
                {
                    changeA = +0.05f;
                }
                colorNg.a += changeA;
                sunLight.GetComponent<Image>().color = colorNg;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}