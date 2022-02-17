public interface IStateMachine
{
    void SwitchState<T>() where T : PlayerState;
    void Init();
}
