using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
    int StageNo=2;
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
            Color colorNg = sunLight.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            float changeA = 0.01f;
            while (true)
            {
                Debug.Log("colorNg.a " + colorNg.a);
                if (colorNg.a >= 0.9)
                    changeA = -0.05f;
                else if (colorNg.a <= 0.6)
                {
                    changeA = +0.05f;
                }
                colorNg.a += changeA;
                sunLight.transform.GetChild(0).GetComponent<SpriteRenderer>().color = colorNg;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
