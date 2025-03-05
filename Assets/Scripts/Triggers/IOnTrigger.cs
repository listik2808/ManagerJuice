using System;

namespace Scripts.Triggers
{
    public interface IOnTrigger
    {
        void Enter();
    }

    public interface IOnTriggerExit: IOnTrigger
    {
        void Exit();
    }
}
