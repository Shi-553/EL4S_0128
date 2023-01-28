public class UFO : FloatingMatter
{
    protected override void Explosion(BreakInfo info)
    {
        var others = transform.parent.GetComponentsInChildren<FloatingMatter>();
        foreach (var other in others)
        {
            other.BreakImmediate();
        }
    }

}
