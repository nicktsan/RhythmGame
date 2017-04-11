using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    List<float> whichNote = new List<float>() { 1, 2, 3, 4, 5, 6, 7, 8};

    List<float> whichTime = new List<float>() { .1f, .5f, 1, .75f, 1.5f, 2f, .4f, .6f };

    public int noteMark = 0;

    public Transform noteObj;

    public Transform Camera;

    public KeyCode PauseKey;

    public string timerReset = "y";

    public float xPos;
	// Use this for initialization
	void Start () {
        Camera.position = new Vector3(Camera.position.x, Camera.position.y, 1.5f);
        

}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(PauseKey))
        {

        }

        if (timerReset == "y" && noteMark < whichNote.Count)
        {
            StartCoroutine(spawnNote());
            timerReset = "n";
        }
		
	}

    IEnumerator spawnNote()
    {
        yield return new WaitForSeconds(whichTime[noteMark]);

        if (whichNote[noteMark] == 1)
        {
            xPos = -5.0f;
        }
        if (whichNote[noteMark] == 2)
        {
            xPos = -3.57f;
        }
        if (whichNote[noteMark] == 3)
        {
            xPos = -2.14f;
        }
        if (whichNote[noteMark] == 4)
        {
            xPos = -0.71f;
        }
        if (whichNote[noteMark] == 5)
        {
            xPos = 0.71f;
        }
        if (whichNote[noteMark] == 6)
        {
            xPos = 2.14f;
        }
        if (whichNote[noteMark] == 7)
        {
            xPos = 3.57f;
        }
        if (whichNote[noteMark] == 8)
        {
            xPos = 5.0f;
        }

        noteMark += 1;
        timerReset = "y";
        Instantiate(noteObj, new Vector3(xPos, 5.07f, 16.84f), noteObj.rotation);
    }
}
