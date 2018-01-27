using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leavefall : MonoBehaviour {

    float x;
    float y;
    int count = 0;
    bool left = true;

	// Use this for initialization
	void Start () {
        StartCoroutine("leaveFall");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator leaveFall()
    {
        do {
            y = transform.localPosition.y - 2.5f;
            if (count == 100)
            {
                left = false;
            }
            else if (count == 0)
            {
                left = true;
            }

            if (left == true)
            {
                x = transform.localPosition.x + 3f;
                transform.Rotate(new Vector3(0, 0, 80) * Time.deltaTime);
                count++;
            }
            else if (left == false)
            {
                x = transform.localPosition.x - 3f;
                transform.Rotate(new Vector3(0, 0, -80) * Time.deltaTime);
                count--;
            }
            this.transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            yield return new WaitForSeconds(0.05f);
        } while (this.transform.localPosition.y >= -500);
        Destroy(this.gameObject);
    }
}
