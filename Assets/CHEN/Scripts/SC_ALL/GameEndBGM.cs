using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndBGM : MonoBehaviour
{
    public GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM.GetComponent<BG_MainCTL>().BGM_OVER();
    }


}
