using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Linq;

public class GameStart : MonoBehaviour {

    //Sonic annotator directory: D:\Homework\CSC475\rhythm_game\Rhythm_Game\sonic-annotator-1.4-win32\release
    // run melodia with sonic annotator: sonic-annotator.exe -d vamp:mtg-melodia:melodia:melody C:\audio\song.wav -w csv
    public string gameDirectory = Directory.GetCurrentDirectory();
    public Text currSong;
    public List<double> freq;
    public List<double> time;

    public void makeCSV()
    {
        Process p = new Process();
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "cmd.exe";
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;

        p.StartInfo = info;
        //print("sonic-annotator.exe -d vamp:mtg-melodia:melodia:melody " + currSong.text + " -w csv");
        p.Start();
        using (StreamWriter sw = p.StandardInput)
        {
            if (sw.BaseStream.CanWrite)
            {
                sw.WriteLine("cd sonic-annotator-1.4-win32\release");
                sw.WriteLine("sonic-annotator.exe -d vamp:mtg-melodia:melodia:melody " + currSong.text + " -w csv");
            }
        }
        p.Close();
    }

    public void CSVtoArray()
    {
        string fname = Path.GetFileNameWithoutExtension(gameDirectory + @"\Assets\Audio\" + currSong.text) + "_vamp_mtg-melodia_melodia_melody.csv";
        string csvpath = gameDirectory + @"\Assets\Audio\" + fname;
        freq = new List<double>();
        time = new List<double>();
        StreamReader sr = new StreamReader(csvpath);
        while (!sr.EndOfStream)
        {
            string strline = sr.ReadLine();
            string[] values = strline.Split(',');
            freq.Add(double.Parse(values[0]));
            time.Add(double.Parse(values[1]));
        }
        //print(freq[900]);
    }
}