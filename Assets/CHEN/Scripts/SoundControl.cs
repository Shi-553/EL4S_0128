using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [Header("呼び出す関数：　Play_BG()  Stop_BG()")]
    [Header("最大音量調整：　Max_Vol")]

    public float Max_Vol = 1.0f;

    private bool is_BG = false;
    private float VOL_BG = 0.0f;
    private float VOL_ChangeSpeed = 0.5f;
    private AudioSource AUDIOSOURCE;

    // Start is called before the first frame update
    void Start()
    {
        AUDIOSOURCE = gameObject.GetComponent<AudioSource>();
        AUDIOSOURCE.volume = VOL_BG;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_BG)
        {
            if (VOL_BG < Max_Vol) VOL_BG += Time.deltaTime * VOL_ChangeSpeed * Max_Vol;
        }
        if(!is_BG)
        {
            if (VOL_BG > 0.0f) VOL_BG -= Time.deltaTime * VOL_ChangeSpeed;
            if (VOL_BG <= 0.0f) AUDIOSOURCE.Stop();
        }
        AUDIOSOURCE.volume = VOL_BG;








        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Play_BG();
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    Stop_BG();
        //}



    }


    public void Play_BG()
    {
        is_BG = true;
        AUDIOSOURCE.Play();
    }

    public void Stop_BG()
    {
        is_BG = false;
    }


}
