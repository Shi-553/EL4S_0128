using UnityEngine;

public class Meteorite : FloatingMatter
{
    [SerializeField]
    float range = 1;
    [SerializeField]
    float explosionPower = 1;
    protected override void Explosion(BreakInfo info)
    {
        var overlaps = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var collision in overlaps)
        {
            if (collision.TryGetComponent<FloatingMatter>(out var other))
            {
                var toOther = other.transform.position - transform.position;
                var dir = toOther.normalized;
                other.Break(new(dir, other.transform.position, explosionPower));
            }
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
#endif
}
