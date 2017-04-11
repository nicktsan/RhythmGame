using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour {

    public KeyCode ActivateString;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(ActivateString))
        {
            GetComponent<Rigidbody>().position = new Vector3(transform.position.x, transform.position.y, 9);
            StartCoroutine(retractCollider());

        }
	}

    IEnumerator retractCollider()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<Rigidbody>().position = new Vector3(transform.position.x, transform.position.y, 5);
    }
}
