using System.Linq;
using UnityEngine;

[System.Serializable]
public class FloatingMatterSpawnInfo
{
    public FloatingMatter floatingMatterPrefab;
    public float probability = 1;
}

public class FloatingMatterGenerator : MonoBehaviour
{
    [SerializeField]
    FloatingMatterSpawnInfo[] floatingMatterSpawnInfos;

    [SerializeField]
    float spawnInterval = 0.1f;
    float time = 0;

    [SerializeField]
    float speed = 10;

    [SerializeField]
    Transform target;

    float probabilityMax;

    Vector2[] positions;
    void Start()
    {
        probabilityMax = floatingMatterSpawnInfos.Sum(s => s.probability);

        var camera = Camera.main;
        positions = new Vector2[] {
            camera.ScreenToWorldPoint(new(0,Screen.height/2)),
            camera.ScreenToWorldPoint(new(0,Screen.height)),
            camera.ScreenToWorldPoint(new(Screen.width,Screen.height)),
            camera.ScreenToWorldPoint(new(Screen.width,Screen.height/2)),
        };
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnInterval)
        {
            time = 0;

            var floatimgMatter = SpawnFloatingMatter();

            floatimgMatter.transform.position = GetRandomPos();

            var fouce = (target.position - floatimgMatter.transform.position).normalized;
            floatimgMatter.AddForce(fouce * speed);
        }
    }

    FloatingMatter SpawnFloatingMatter()
    {
        float val = Random.Range(0, probabilityMax);

        foreach (var info in floatingMatterSpawnInfos)
        {
            val -= info.probability;
            if (val <= 0)
            {
                return Instantiate(info.floatingMatterPrefab, transform);
            }
        }
        throw new System.Exception("‚ ‚è‚¦‚È‚¢");
    }

    Vector2 GetRandomPos()
    {

        var val = Random.Range(0.0f, positions.Length - 1 - 0.001f);

        var floorIndex = Mathf.FloorToInt(val);
        var floor = positions[floorIndex];
        var ceil = positions[floorIndex + 1];

        return Vector2.Lerp(floor, ceil, val - floorIndex);
    }
}
