using Ito.GameState;
using System.Collections;
using UnityEngine;
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
            if (PlayerManager.GetHealth() <= 0) { ReloadScene(); }

            if (BattleManager.CurrentMonster.GetHealth() <= 0) { return new GameRefleshState(StateMachine); }

            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            GameManager.IsBattle = true;

            BattleManager.OnPlayerBattleEvent += BattleManager.OnPlayerBattle;
            BattleManager.OnEnemyBattleEvent += BattleManager.OnEnemyBattle;

            //if (BattleManager.OnPlayEnterEvent != null)
            //{
            //    BattleManager.OnPlayEnterEvent();
            //}

            StartCoroutine(CoPlaying());
        }

        IEnumerator CoPlaying()
        {
            while (true)
            {
                yield return new WaitUntil(() => !GameManager.IsAnimation);

                if (BattleManager.CheckPlayerAttack())
                {
                    if (BattleManager.OnPlayerBattleEvent != null) { BattleManager.OnPlayerBattleEvent(); }
                }

                yield return new WaitUntil(() => !GameManager.IsAnimation);

                if (BattleManager.CheckEnemyAttack())
                {
                    if (BattleManager.OnEnemyBattleEvent != null) { BattleManager.OnEnemyBattleEvent(); }
                }

                yield return null;
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            GameManager.IsBattle = false;

            BattleManager.ExitBattle();

            BattleManager.OnPlayerBattleEvent -= BattleManager.OnPlayerBattle;
            BattleManager.OnEnemyBattleEvent -= BattleManager.OnEnemyBattle;

            //if (BattleManager.OnPlayExitEvent != null)
            //{
            //    BattleManager.OnPlayExitEvent();
            //}
            //BGMManager.Current.Stop();
        }
    }
}