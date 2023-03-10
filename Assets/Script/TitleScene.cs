using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class TitleScene : MonoBehaviour
{

    [SerializeField] GameObject cocoontower;
    [SerializeField] VisualEffect frameParticle;
    [SerializeField] VisualEffect smokeParticle;
    [SerializeField] VisualEffect smokeBottomParticle;
    [SerializeField] Button startButton;
    [SerializeField] Button firingButton;
    [SerializeField] Button effectButton;
    [SerializeField] Animator filingAnimation;
    [SerializeField] Sprite buttonDown;
    [SerializeField] Sprite buttonUp;

    [SerializeField] float TimeMax = 0.0f;
    float time = 0.0f;
    bool IsTakeOff = false;

    // Start is called before the first frame update
    void Start()
    {
        frameParticle.Stop();
        smokeParticle.Stop();
        smokeBottomParticle.Stop();
        effectButton.gameObject.SetActive(false);
        firingButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0.0f)
        {
            time -= Time.deltaTime;
            smokeParticle.SetVector3("Position", new Vector3(0, cocoontower.transform.position.y, 0));

        }
        else if(time <= 0.0f)
        {
            time = 0.0f;
            if (IsTakeOff)
            {
                IsTakeOff = false;
                frameParticle.Stop();
                smokeParticle.Stop();
                smokeBottomParticle.Stop();
                Fade.Instance.ChangeScene("GameUI", 1.0f, 0.0f, 1.0f, 0.0f);
            }

        }
    }

    public void GameStart(){
        filingAnimation.SetBool("IsStart", true);
        startButton.gameObject.SetActive(false);
        effectButton.gameObject.SetActive(true);
    }

    public void FiringStart()
    {
        time = TimeMax;
        firingButton.gameObject.SetActive(false);
        filingAnimation.SetBool("IsFiling", true);
        IsTakeOff = true;
    }

    public void EffectStart()
    {
        frameParticle.Play();
        smokeParticle.Play();
        smokeBottomParticle.Play();
        effectButton.gameObject.SetActive(false);
        firingButton.gameObject.SetActive(true);
    }

    public void ButtonDown()
    {
        startButton.image.sprite = buttonDown;
        effectButton.image.sprite = buttonDown;
        firingButton.image.sprite = buttonDown;
    }

    public void ButtonUp()
    {
        startButton.image.sprite = buttonUp;
        effectButton.image.sprite = buttonUp;
        firingButton.image.sprite = buttonUp;
    }
}
