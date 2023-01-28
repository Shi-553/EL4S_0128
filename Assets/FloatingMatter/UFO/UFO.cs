using System.Collections;
using UnityEngine;

public class UFO : FloatingMatter
{
    [SerializeField]
    float speed = 0.1f;
    [SerializeField]
    float moveDuration = 1;
    [SerializeField]
    float lifeDuration = 5;

    protected override void InitImpl()
    {
        StartCoroutine(Move());
    }
    protected override void Explosion(BreakInfo info)
    {
        var others = transform.parent.GetComponentsInChildren<FloatingMatter>();
        foreach (var other in others)
        {
            other.BreakImmediate();
        }
    }
    IEnumerator Move()
    {
        bool isRight = true;
        float time = Time.time;
        while (true)
        {
            rigid.velocity = Vector2.zero;
            var val = (isRight ? Vector2.right : Vector2.left);
            AddForce(speed * val);
            yield return new WaitForSeconds(moveDuration);

            if (Time.time - time > lifeDuration)
            {
                yield return new WaitForSeconds(5);
                Destroy(gameObject);
                yield break;
            }
            isRight = !isRight;
        }
    }
}
