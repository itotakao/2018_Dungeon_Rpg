using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class GameStartState : State
    {
        bool isFinish = false;

        public GameStartState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (isFinish) { return new GameRefleshState(StateMachine); }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            GameManager.Reflesh();

            TitleUI.Show(false);
            TownUI.Show(false);
            GameUI.Show(true);

            BattleUI.Show(false);

            //StartCoroutine(CoTransitionEffect());
            FadeManager.isFadeIn = true;
            isFinish = true;
        }

        IEnumerator CoTransitionEffect()
        {
            FadeManager.isFadeOut = true;

            yield return new WaitForSeconds(2);

            FadeManager.isFadeIn = true;

            isFinish = true;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            isFinish = false;
        }
    }
}