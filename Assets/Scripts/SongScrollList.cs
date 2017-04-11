using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public class Song
{
    public string songName;
}

public class SongScrollList : MonoBehaviour
{
    public List<Song> songList;
    public Transform contentPanel;
    public Text selectedSong;
    public SimpleObjectPool buttonObjectPool;
    public string gameDirectory = Directory.GetCurrentDirectory();

    // Use this for initialization
    void Start ()
    {
        fillList();
        RefreshDisplay();
	}
	
    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void fillList()
    {
        try
        {
            string wavpath = gameDirectory + @"\Assets\Audio\";
            string[] dirs = Directory.GetFiles(wavpath, "*.wav")
                                     .Select(Path.GetFileName)
                                     .ToArray();
            foreach (string dir in dirs)
            {
                Song newSong = new Song();
                newSong.songName = dir;
                songList.Add(newSong);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < songList.Count; i++)
        {
            Song song = songList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(song, this);   
        }
    }

    public void selectSong(string currSong)
    {
        selectedSong.text = currSong;
        RefreshDisplay();
    }
}
