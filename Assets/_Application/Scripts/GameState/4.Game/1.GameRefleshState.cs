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
            GameManager.Reflesh();
            StartCoroutine(CoReflesh());
        }

        IEnumerator CoReflesh(){
            FadeManager.isFadeOut = true;
            TurnManager.AddTurn();
            yield return new WaitForSeconds(2);
            FadeManager.isFadeIn = true;

            // CardManager.ShuffleCard(); // 使わなくなった
            BattleManager.CallRandamMonster();

            yield return new WaitForSeconds(2);
            isFinish = true;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}