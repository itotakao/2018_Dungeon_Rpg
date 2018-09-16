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
            if (PlayerManager.Health <= 0) { ReloadScene(); }

            if (BattleManager.CurrentMonster.GetHealth() <= 0) { return new GameRefleshState(StateMachine); }

            if (GameManager.IsNextTurn) {

                GameManager.IsNextTurn = false;



                return new GamePlayState(StateMachine);
            }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            BattleManager.OnPlayEvent += BattleManager.OnPlayerBattle;
            BattleManager.OnPlayEvent += BattleManager.OnEnemyBattle;


            //if (BattleManager.OnPlayEnterEvent != null)
            //{
            //    BattleManager.OnPlayEnterEvent();
            //}

            StartCoroutine(CoPlaying());
        }

        IEnumerator CoPlaying(){
            while (true)
            {
                if(BattleManager.OnPlayEvent != null)
                {
                    BattleManager.OnPlayEvent();
                }
                yield return null;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            BattleManager.OnPlayEvent -= BattleManager.OnPlayerBattle;
            BattleManager.OnPlayEvent -= BattleManager.OnEnemyBattle;

            //if (BattleManager.OnPlayExitEvent != null)
            //{
            //    BattleManager.OnPlayExitEvent();
            //}
            //BGMManager.Current.Stop();
        }
    }
}