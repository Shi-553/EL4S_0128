using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    [SerializeField] private Text ClearText;
    [SerializeField] private GameObject[] Player = new GameObject[3];

    private static int damage;  //コクーンタワーの状況 (0:ノーダメージ / 1:小破 / 2:中破)

    private float[] time = new float[2];
    private float[] downTime = new float[2];


    // Start is called before the first frame update
    void Start()
    {
        time[0] = time[1] = 0;
        downTime[0] = 0.01f;
        downTime[1] = 0.005f;
        damage = 0;

        ClearText.rectTransform.localPosition = new Vector3(0, 400.0f, 0);
        for (int i = 0; i < 3; i++)
        {
            Player[i].transform.position = new Vector3(0, 8.0f, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TextDown();
        PlayerDown();
    }

    //テキスト移動処理
    private void TextDown()
    {
        if (ClearText.rectTransform.localPosition.y > 250.0f)
        {
            time[0] += Time.deltaTime;
            if (downTime[0] < time[0])
            {
                ClearText.rectTransform.localPosition += new Vector3(0, -1.0f, 0);
                time[0] = 0;
            }
        }
        else
        {
            ClearText.rectTransform.localPosition = new Vector3(0, 250.0f, 0);
        }
    }

    //コクーンタワー着陸処理
    private void PlayerDown()
    {
        if (Player[damage].transform.position.y > 1.0f)
        {
            time[1] += Time.deltaTime;
            if (downTime[1] < time[1])
            {
                Player[damage].transform.position += new Vector3(0, -0.07f, 0);
                time[1] = 0;
            }
        }
        else if (Player[damage].transform.position.y > 0.0f)
        {
            time[1] += Time.deltaTime;
            if (downTime[1] < time[1])
            {
                Player[damage].transform.position += new Vector3(0, -0.035f, 0);
                time[1] = 0;
            }
        }
        else if (Player[damage].transform.position.y > -0.75f)
        {
            time[1] += Time.deltaTime;
            if (downTime[1] < time[1])
            {
                Player[damage].transform.position += new Vector3(0, -0.01f, 0);
                time[1] = 0;
            }
        }
        else
        {
            Player[damage].transform.position = new Vector3(0, -0.75f, 0);
        }
    }
}
