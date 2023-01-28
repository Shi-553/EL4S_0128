using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ResultScript : MonoBehaviour
{
    [SerializeField] private Text ClearText;
    [SerializeField] private GameObject[] Player = new GameObject[3];

    public static int damage;  //�R�N�[���^���[�̏� (0:�m�[�_���[�W / 1:���j / 2:���j)

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

        ClearText.rectTransform.localPosition = new Vector3(0, 400.0f, 0);
        for (int i = 0; i < 3; i++)
        {
            Player[i].transform.position = new Vector3(0, 10.0f, 0);
            Player[i].transform.Find("FrameParticle").GetComponent<VisualEffect>().Stop();  //���A�j���[�V�������~�߂�
            Player[i].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Stop();  //���A�j���[�V�������~�߂�
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

    //�e�L�X�g�ړ�����
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

    //�R�N�[���^���[��������
    private void PlayerDown()
    {
        if(!isStart)
        {
            Player[damage].transform.Find("FrameParticle").GetComponent<VisualEffect>().Play();  //���A�j���[�V�������n�߂�
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
                Player[damage].transform.Find("FrameParticle").GetComponent<VisualEffect>().Stop();  //���A�j���[�V�������~�߂�
                Player[damage].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Play();  //���A�j���[�V�������n�߂�
                audioSource.PlayOneShot(Landing_SE);
                isLanding = true;
            }

            Invoke("Clear", 1.0f);
        }
    }

    //�N���A����
    private void Clear()
    {
        if(!isClear)
        {
            Player[damage].transform.Find("SmokeBaseParticle").GetComponent<VisualEffect>().Stop();  //���A�j���[�V�������~�߂�
            audioSource.PlayOneShot(Clear_SE);
            isClear = true;
        }
    }
}
