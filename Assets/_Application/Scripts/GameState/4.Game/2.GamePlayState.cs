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
            if (GameManager.IsNextTurn) {

                GameManager.IsNextTurn = false;

                if (PlayerManager.Health <= 0) { ReloadScene(); }

                if (BattleManager.CurrentMonster.GetHealth() <= 0){ return new GameRefleshState(StateMachine); }

                return new GamePlayState(StateMachine);
            }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            if (BattleManager.OnPlayEnterEvent != null)
            {
                BattleManager.OnPlayEnterEvent();
            }

            //StartCoroutine(CoPlaying());
        }

        IEnumerator CoPlaying(){
            yield return null;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            if (BattleManager.OnPlayExitEvent != null)
            {
                BattleManager.OnPlayExitEvent();
            }
            //BGMManager.Current.Stop();
        }
    }
}