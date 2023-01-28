using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tittle_SoundCTL : MonoBehaviour
{
    public GameObject SE_CTL;
    public GameObject BGM_CTL;


    private int State = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(State==0)
        {
            BGM_CTL.GetComponent<BG_MainCTL>().BGM_OPENING();
            State = 1;
        }

        if(State==2)
        {
            BGM_CTL.GetComponent<BG_MainCTL>().BGM_EVENT();
            State = 3;
        }


        
    }





    public void STATEPLUS()
    {
        State++;
    }
}
