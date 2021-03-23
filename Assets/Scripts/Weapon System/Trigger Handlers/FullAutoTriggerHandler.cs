public class FullAutoTriggerHandler : BaseTriggerHandler
{
    public override event OnTriggerAttack OnTrigger = delegate { };

    public override bool TriggerAttack()
    {
        OnTrigger.Invoke();

        return true;
    }
}
