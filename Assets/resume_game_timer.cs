using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resume_gameTimer : MonoBehaviour {
    public Text timer;
	// Use this for initialization
	void Start () {
        timer.text = "3";
        timer = GameObject.Find("Timer").GetComponent(Text);
	}
	
	// Update is called once per frame
	void Update () {
		int timeLeft = 3 - Time.time;
        if (timeLeft < 0) timeLeft = 0;
        timer.text = timeLeft.ToString();
	}
}
