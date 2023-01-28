using System.Collections;
using UnityEngine;

public readonly struct BreakInfo
{
    public readonly Vector2 direction;
    public readonly Vector2 hitPos;
    public readonly float power;

    public BreakInfo(Vector2 direction, Vector2 hitPos, float power)
    {
        this.direction = direction;
        this.hitPos = hitPos;
        this.power = power;
    }
}

public abstract class FloatingMatter : MonoBehaviour
{
    [SerializeField]
    float timeToExplotion = 0.1f;

    Rigidbody2D rigid;
    protected virtual void Awake()
    {
        TryGetComponent(out rigid);
    }
    public void AddForceAtPosition(Vector2 fouce, Vector2 pos)
    {
        rigid.AddForceAtPosition(fouce, pos, ForceMode2D.Impulse);
    }
    public void AddForce(Vector2 fouce)
    {
        rigid.AddForce(fouce, ForceMode2D.Impulse);
    }

    bool isBreaked = false;
    public void BreakImmediate()
    {
        if (isBreaked)
            return;
        isBreaked = true;

        Destroy(gameObject);
    }
    public void Break(BreakInfo info)
    {
        if (isBreaked)
            return;
        isBreaked = true;


        GetComponent<SpriteRenderer>().color = Color.red;

        AddForceAtPosition(info.direction * info.power, info.hitPos);
        gameObject.layer = LayerMask.NameToLayer("FloatingMatterBlock");
        StartCoroutine(WaitExplosion(info));

    }
    IEnumerator WaitExplosion(BreakInfo info)
    {
        yield return new WaitForSeconds(timeToExplotion);
        Explosion(info);
        Destroy(gameObject);
    }
    protected abstract void Explosion(BreakInfo info);


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BreakImmediate();
        }
        if (collision.gameObject.TryGetComponent<FloatingMatter>(out var floatingMatter))
        {
            var contact = collision.contacts[0];
            floatingMatter.Break(new(contact.normal, contact.point, 0));
        }
    }

}