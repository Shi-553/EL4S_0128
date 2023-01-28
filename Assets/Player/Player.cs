using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int missileCountMax = 3;
    float missileCount = 3;
    [SerializeField]
    float missileReloadTime = 3;

    [SerializeField]
    Missile missilePrefab;

    [SerializeField]
    int lifeMax = 3;
    int life = 3;

    Camera mainCamera;
    void Start()
    {
        ResultScript.damage = 0;
        life = lifeMax;
        missileCount = missileCountMax;
        mainCamera = Camera.main;
        StartCoroutine(UpdateLoop());
    }

    public void Damaged()
    {
        if (life <= 0)
            return;
        life--;
        ResultScript.damage++;
        if (life <= 0)
        {
            Debug.Log("Ž€‚ñ‚¾");
        }
    }
    IEnumerator UpdateLoop()
    {
        while (true)
        {
            missileCount = missileCountMax;
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
                yield break;
            }
        }
    }
}
