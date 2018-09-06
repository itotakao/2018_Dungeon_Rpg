using Ito.GameState;
using System.Collections;

namespace Ito
{
    public class GamePlayState : State
    {
        public GamePlayState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (GameManager.IsNextTurn) { return new GameRefleshState(StateMachine); }
            //if (Game.IsGameOver) { return new ResultStartState(StateMachine); }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            if (EventManager.OnPlayEnterEvent != null)
            {
                EventManager.OnPlayEnterEvent();
            }

            StartCoroutine(CoPlaying());
        }

        IEnumerator CoPlaying(){
            yield return null;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            if (EventManager.OnPlayExitEvent != null)
            {
                EventManager.OnPlayExitEvent();
            }
            //BGMManager.Current.Stop();
        }
    }
}