using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    int missileCountMax = 3;
    int missileCount = 3;
    [SerializeField]
    float missileReloadTime = 3;

    [SerializeField]
    Missile missilePrefab;

    [SerializeField]
    int lifeMax = 3;

    [SerializeField]
    SpriteRenderer[] missiles;

    public int Life { get; private set; }

    Camera mainCamera;
    void Start()
    {
        ResultScript.damage = 0;
        Life = lifeMax;
        missileCount = missileCountMax;
        mainCamera = Camera.main;
        StartCoroutine(UpdateLoop());
    }

    public void Damaged()
    {
        if (Life <= 0)
            return;
        Life--;
        ResultScript.damage++;
        if (Life <= 0)
        {
            SceneManager.LoadScene("ResultScene");
            Debug.Log("Ž€‚ñ‚¾");
        }
    }
    IEnumerator UpdateLoop()
    {
        while (true)
        {
            missileCount = missileCountMax;
            foreach (var m in missiles)
            {
                m.color = Color.white;
            }
            while (missileCount > 0)
            {
                yield return WaitMouseButtonLoop();

            }
            yield return new WaitForSeconds(missileReloadTime);
        }
    }
    IEnumerator WaitMouseButtonLoop()
    {
        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                missileCount--;
                missiles[missileCount].color = Color.gray;

                Vector3 screenMousePos = Input.mousePosition;
                screenMousePos.z = 10;
                var worldMousePos = mainCamera.ScreenToWorldPoint(screenMousePos);

                var missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                var dir = (worldMousePos - transform.position).normalized;

                missile.Init(dir);

                yield break;
            }
            if (Input.GetMouseButtonDown(1))
            {
                missileCount = 0;

                foreach (var m in missiles)
                {
                    m.color = Color.gray;
                }
                yield break;
            }
        }
    }
}
