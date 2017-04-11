using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {

    public Button button;
    public Text nameLabel;

    private Song song;
    private SongScrollList scrollList;

	// Use this for initialization
	void Start ()
    {
        button.onClick.AddListener(HandleClick);	
	}

    public void Setup(Song currentSong, SongScrollList currentScrollList)
    {
        song = currentSong;
        nameLabel.text = song.songName;

        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        scrollList.selectSong(nameLabel.text);
    }
}
