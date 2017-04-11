using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unpause : MonoBehaviour {
    public GameObject resume_timer;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            resume_timer.SetActive(true);
        }
	}
}
