
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Digital_Clock : UdonSharpBehaviour
{
    public Text textClock;
    void Start()
    {
        textClock = GetComponent<Text>();
    }

    void Update()
    {
        DateTime time = DateTime.Now;

        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        textClock.text = hour + ":" + minute + ":" + second;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
