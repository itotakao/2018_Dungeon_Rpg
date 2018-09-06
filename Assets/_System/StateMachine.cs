using Ito.GameState;
using Ito;

public class StateMachine : GameStateMachine
{
    public override GameState DefaultState
    {
        get
        {
            return new TitleState(this);
        }
    }
}
