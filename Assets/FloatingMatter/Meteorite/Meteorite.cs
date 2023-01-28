using UnityEngine;

public class Meteorite : FloatingMatter
{
    [SerializeField]
    float range = 1;
    protected override void Explosion(BreakInfo info)
    {
        var overlaps = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var collision in overlaps)
        {
            if (collision.TryGetComponent<FloatingMatter>(out var other))
            {
                var toOther = other.transform.position - transform.position;
                var power = toOther.magnitude;
                var dir = toOther / power;
                other.Break(new(dir, other.transform.position, power));
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
