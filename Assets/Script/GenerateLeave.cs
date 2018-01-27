using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLeave : MonoBehaviour {

    GameObject leavePrefab;
    public GameObject leave1;
    public GameObject leave2;
    public GameObject parent;

	// Use this for initialization
	void Start () {
        StartCoroutine("leaveGenerate");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator leaveGenerate()
    {
        for (;;)
        {
            leavePrefab = Instantiate(leave1, new Vector3(Random.Range(-800, 800), 500, 10), Quaternion.identity);
            leavePrefab.transform.SetParent(parent.transform,false);
            leavePrefab.AddComponent<Leavefall>();
            yield return new WaitForSeconds(3f);
            leavePrefab = Instantiate(leave2, new Vector3(Random.Range(-800, 800), 500, 10), Quaternion.identity);
            leavePrefab.transform.SetParent(parent.transform, false);
            leavePrefab.AddComponent<Leavefall>();
            yield return new WaitForSeconds(3f);
        }
    }
}
