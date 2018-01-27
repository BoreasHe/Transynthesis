using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFlashing : MonoBehaviour {

    public Image pressStart;
    static bool full = false;

	// Use this for initialization
	void Start () {
        StartCoroutine("flashingwait");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void flashing()
    {
        Color c = pressStart.color;
        if (c.a >= 1)
        {
            full = true;
        }
        else if (c.a <= 0)
        {
            full = false;
        }

        if (full == true)
        {
            c.a -= 0.1f;
        }
        else if (full == false)
        {
            c.a += 0.1f;
        }
        pressStart.color = c;
    }

    IEnumerator flashingwait()
    {
        for (;;)
        {
            flashing();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
