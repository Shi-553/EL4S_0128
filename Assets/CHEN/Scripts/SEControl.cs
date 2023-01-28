using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SEControl : MonoBehaviour
{
    [Header("�Ăяo���֐��F�@Instantiate()")]
    [Header("�ő剹�ʒ����F�@Vol")]
    public float Vol = 1.0f;

    private float Timer = 0.0f;

    private void Start()
    {
        GetComponent<AudioSource>().volume = Vol;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 2.0f) Destroy(this.gameObject);
    }
}
