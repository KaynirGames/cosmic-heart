public class NoAmmoHandler : BaseAmmoHandler
{
    public override bool CheckAmmo()
    {
        return true;
    }

    public override void ConsumeAmmo() { }

    public override void Reload() { }
}
