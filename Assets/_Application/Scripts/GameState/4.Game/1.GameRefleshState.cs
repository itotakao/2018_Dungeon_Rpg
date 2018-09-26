using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class GameRefleshState : State
    {
        bool isFinish = false;

        public GameRefleshState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            return isFinish ? new GamePlayState(StateMachine) : null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Reflesh();
            StartCoroutine(CoReflesh());
        }

        IEnumerator CoReflesh()
        {
            BattleUI.Show(false);

            yield return new WaitForSeconds(2);

            BattleUI.Show(true);
            //TurnManager.AddTurn();
            BattleManager.CallRandamMonster();

            isFinish = true;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public void Reflesh()
        {
            GameManager.Reflesh();
            PlayerManager.Reflesh();
            BattleManager.Reflesh();
        }
    }
}