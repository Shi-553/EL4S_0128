using UnityEngine;

public class Missile : MonoBehaviour
{
    bool isBreak = false;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float impulse = 0.2f;
    public void Init(Vector3 dir)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        GetComponent<Rigidbody2D>().AddForce(dir * speed, ForceMode2D.Impulse);
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreak)
            return;
        if (collision.gameObject.TryGetComponent<FloatingMatter>(out var floatingMatter))
        {
            isBreak = true;
            var contact = collision.contacts[0];

            floatingMatter.Break(new(-contact.normal, contact.point, contact.normalImpulse * impulse));
            Destroy(gameObject);
        }
    }
}
