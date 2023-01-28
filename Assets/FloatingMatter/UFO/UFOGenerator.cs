using System.Collections;
using UnityEngine;

public class UFOGenerator : MonoBehaviour
{
    [SerializeField]
    float generateInterval = 8;

    [SerializeField]
    UFO ufoPrefab;

    [SerializeField]
    Vector2 spawnPos = new(-3.48f, 4.0f);
    void Start()
    {
        StartCoroutine(GenerateLoop());
    }

    IEnumerator GenerateLoop()
    {
        while (true)
        {
            var ufo = Instantiate(ufoPrefab, spawnPos, Quaternion.identity, transform);
            ufo.Init(null);
            yield return new WaitForSeconds(generateInterval);
        }
    }

}
