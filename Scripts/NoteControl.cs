using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour {

    public Transform successBurst;
    public Transform FailBurst;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FailCollider")
        {
            Destroy(gameObject);
            Debug.Log("fail");
            Instantiate(FailBurst, transform.position, FailBurst.rotation);
        }

        if(other.gameObject.name == "Success")
        {
            Destroy(gameObject);
            Debug.Log("Success");
            Instantiate(successBurst, transform.position, successBurst.rotation);
        }
    }
}
