using UnityEngine;

public class BreakTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<FloatingMatter>(out var floatingMatter))
        {
            var contact = other.contacts[0];
            floatingMatter.Break(new(-contact.normal, contact.point, contact.normalImpulse));
        }
    }
}
