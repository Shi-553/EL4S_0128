using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MainCTL : MonoBehaviour
{
    public GameObject Opening;
    public GameObject Event;
    public GameObject Playing;
    public GameObject Ending;
    public GameObject Over;





    public void BGM_OPENING()
    {
        Opening.GetComponent<SoundControl>().Play_BG();

        Event.GetComponent<SoundControl>().Stop_BG();
        Playing.GetComponent<SoundControl>().Stop_BG();
        Ending.GetComponent<SoundControl>().Stop_BG();
        Over.GetComponent<SoundControl>().Stop_BG();
    }

    public void BGM_EVENT()
    {
        Event.GetComponent<SoundControl>().Play_BG();

        Opening.GetComponent<SoundControl>().Stop_BG();
        Playing.GetComponent<SoundControl>().Stop_BG();
        Ending.GetComponent<SoundControl>().Stop_BG();
        Over.GetComponent<SoundControl>().Stop_BG();
    }

    public void BGM_PLAYING()
    {
        Playing.GetComponent<SoundControl>().Play_BG();

        Opening.GetComponent<SoundControl>().Stop_BG();
        Event.GetComponent<SoundControl>().Stop_BG();
        Ending.GetComponent<SoundControl>().Stop_BG();
        Over.GetComponent<SoundControl>().Stop_BG();
    }

    public void BGM_ENDING()
    {
        Ending.GetComponent<SoundControl>().Play_BG();

        Opening.GetComponent<SoundControl>().Stop_BG();
        Event.GetComponent<SoundControl>().Stop_BG();
        Playing.GetComponent<SoundControl>().Stop_BG();
        Over.GetComponent<SoundControl>().Stop_BG();
    }

    public void BGM_OVER()
    {
        Over.GetComponent<SoundControl>().Play_BG();

        Opening.GetComponent<SoundControl>().Stop_BG();
        Event.GetComponent<SoundControl>().Stop_BG();
        Playing.GetComponent<SoundControl>().Stop_BG();
        Ending.GetComponent<SoundControl>().Stop_BG();
    }

}
