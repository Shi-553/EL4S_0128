using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private static Fade instance;

    public static Fade Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (Fade)FindObjectOfType(typeof(Fade));

                if(instance == null)
                {
                    Debug.LogError(typeof(Fade));
                }
            }

            return instance;
        }
    }

    enum FadeMode
    {
        None,
        In,
        Out,
    }

    [SerializeField] Image fadeImage;


    float fadeInTime = 0.0f;
    float fadeInTimeMax = 0.0f;
    float fadeOutTime = 0.0f;
    float fadeOutTimeMax = 0.0f;
    float fadeInDelayTime = 0.0f;
    float fadeOutDelayTime = 0.0f;
    float fadeAlpha = 0.0f;
    Color fadeColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    string nextScene;

    FadeMode fadeMode = FadeMode.None;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string next, float outtime, float outdelay, float intime, float indelay)
    {
        nextScene = next;

        fadeInTimeMax = fadeInTime = intime;
        fadeOutTimeMax = fadeOutTime = outtime;
        fadeInDelayTime = indelay;
        fadeOutDelayTime = outdelay;

        fadeAlpha = 0.0f;

        fadeMode = FadeMode.Out;

    }

    public void SetColor(Color color)
    {
        fadeColor = color;
    }

    void Update()
    {
        if(fadeMode == FadeMode.Out)
        {
            fadeOutDelayTime -= Time.deltaTime;

            if(fadeOutDelayTime <= 0.0f)
            {
                fadeOutTime -= Time.deltaTime;
                fadeAlpha = 1.0f - fadeOutTime / fadeOutTimeMax;


                if (fadeOutTime <= 0.0f)
                {
                    fadeAlpha = 1.0f;
                    fadeMode = FadeMode.In;
                    if(nextScene == "Exit")
                    {
                        #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
                        #else
                            pplication.Quit();//ゲームプレイ終了
                        #endif
                    }
                    else
                    {
                        SceneManager.LoadScene(nextScene);
                    }
                }
            }
        }
        else if(fadeMode == FadeMode.In)
        {
            fadeInDelayTime -= Time.deltaTime;

            if(fadeInDelayTime <= 0.0f)
            {
                fadeInTime -= Time.deltaTime;
                fadeAlpha = fadeInTime / fadeInTimeMax;

                if (fadeInTime <= 0.0f)
                {
                    fadeAlpha = 0.0f;
                    fadeMode = FadeMode.None;
                }
            }
        }

        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAlpha);
    }
}
