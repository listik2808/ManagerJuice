using System;

namespace Scripts.Triggers
{
    public interface IOnTrigger
    {
        Action EnterTrigger {  get; }
        Action ExitTrigger { get; }

        void Enter();
        void Exit();
    }
}
