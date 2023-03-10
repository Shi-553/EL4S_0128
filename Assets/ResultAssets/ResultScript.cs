using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ResultScript : MonoBehaviour
{
    [SerializeField] private Image ClearImage;
    [SerializeField] private GameObject[] Player = new GameObject[3];

    public static int damage;  //コクーンタワーの状況 (0:ノーダメージ / 1:小破 / 2:中破)

    private float[] time = new float[2];
    private float[] downTime = new float[2];

    private AudioSource audioSource;
    [SerializeField] private AudioClip Move_SE;
    [SerializeField] private AudioClip Landing_SE;
    [SerializeField] private AudioClip Clear_SE;
    private bool isStart;
    private bool isLanding;
    private bool isClear;


    // Start is called before the first frame update
    void Start()
    {
        time[0] = time[1] = 0;
        downTime[0] = 0.01f;
        downTime[1] = 0.005f;
        damage = 0;
        isStart = false;
        isLanding = false;
        isClear = false;

        ClearImage.rectTransform.localPosition = new Vector3(0, 400.0f, 0);
        for (int i = 0; i < 3; i++)
        {
            Player[i].transform.position = new Vector3(0, 10.0f, 0);
            Player[i].transform.Find("FrameParticle").GetComponent<VisualEffect>().Stop();  //炎アニメーションを止める
            Player[i].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Stop();  //煙アニメーションを止める
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Move_SE);

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
        if (ClearImage.rectTransform.localPosition.y > 250.0f)
        {
            time[0] += Time.deltaTime;
            if (downTime[0] < time[0])
            {
                ClearImage.rectTransform.localPosition += new Vector3(0, -1.0f, 0);
                time[0] = 0;
            }
        }
        else
        {
            ClearImage.rectTransform.localPosition = new Vector3(0, 250.0f, 0);
        }
    }

    //コクーンタワー着陸処理
    private void PlayerDown()
    {
        if(!isStart)
        {
            Player[damage].transform.Find("FrameParticle").GetComponent<VisualEffect>().Play();  //炎アニメーションを始める
            isStart = true;
        }

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

            if(!isLanding)
            {
                Player[damage].transform.Find("FrameParticle").GetComponent<VisualEffect>().Stop();  //炎アニメーションを止める
                Player[damage].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Play();  //煙アニメーションを始める
                audioSource.PlayOneShot(Landing_SE);
                isLanding = true;
            }

            Invoke("Clear", 1.0f);
        }
    }

    //クリア処理
    private void Clear()
    {
        if(!isClear)
        {
            Player[damage].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Stop();  //煙アニメーションを止める
            audioSource.PlayOneShot(Clear_SE);
            isClear = true;
        }
    }
}
