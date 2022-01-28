public interface IState
{
    int StatePriority { get; set; }

    bool CanRunState();

    void EnterState();

    void Act();

    void ExitState();
}
