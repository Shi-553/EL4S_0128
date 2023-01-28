using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_MainCTL : MonoBehaviour
{
    public GameObject Damage;
    public GameObject Defeated;
    public GameObject Explosion;
    public GameObject Shot;
    public GameObject Start;
    public GameObject UFO;

    public void SE_DAMAGE()
    {
        Instantiate(Damage);
    }

    public void SE_DEFEATED()
    {
        Instantiate(Defeated);
    }

    public void SE_EXPLOSION()
    {
        Instantiate(Explosion);
    }

    public void SE_SHOT()
    {
        Instantiate(Shot);
    }

    public void SE_START()
    {
        Instantiate(Start);
    }

    public void SE_UFO()
    {
        Instantiate(UFO);
    }
}
