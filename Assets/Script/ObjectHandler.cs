using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour {
    public string objectName;
    public float cloudSpeed = 0;
	// Use this for initialization
	void Start () {
        if (objectName == "Cloud")
            StartCoroutine("SlowingDown");
    }
	
	// Update is called once per frame
	void Update () {
        if (objectName == "Solor")
            SolorRotation();

    }
    void SolorRotation()
    {
        this.gameObject.transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime);
    }
    void CloudMovement()
    {
       if (this.gameObject.transform.localPosition.y <= -89.05)
            cloudSpeed = -0.01f;
        if (this.gameObject.transform.localPosition.y >= -89.00)
            cloudSpeed = 0.01f;
        this.gameObject.transform.position = new Vector3
            (this.gameObject.transform.position.x, this.gameObject.transform.position.y - cloudSpeed, this.gameObject.transform.position.z);

    }
    IEnumerator SlowingDown()
    {
        while (true)
        {
            CloudMovement();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
