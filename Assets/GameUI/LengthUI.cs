using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LengthUI : MonoBehaviour
{
    [SerializeField]
    float clearTime = 30;
    [SerializeField]
    Transform lengthCocoon;
    [SerializeField]
    Image lengthUI;
    IEnumerator Start()
    {
        var player = FindObjectOfType<Player>();

        float time = 0;

        var lengthCocoonBefore = lengthCocoon.localPosition;
        while (true)
        {
            if (time > clearTime)
            {
                break;
            }
            time += Time.deltaTime;

            var t = time / clearTime;
            var r = lengthCocoonBefore;
            r.y = 343.93f;
            lengthCocoon.localPosition = Vector3.Lerp(lengthCocoonBefore, r, t);
            lengthUI.fillAmount = 1 - t;

            yield return null;
        }
        if (player.Life > 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }



}
