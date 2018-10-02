using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ito.GameState;

namespace Ito
{
    public class TownStartState : State
    {
        bool isFinish = false;

        public TownStartState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (isFinish) { return new TownPlayState(StateMachine); }

            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            GameManager.Reflesh();

            TitleScene.Show(false);
            TownScene.Show(true);
            GameScene.Show(false);

            ItemShopUI.Show(false);

            isFinish = true;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            //BGMManager.Current.Stop();
        }
    }
}