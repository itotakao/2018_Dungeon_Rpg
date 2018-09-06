using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class GameChoiceState : State
    {
        bool IsFinish = false;
        public GameChoiceState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (IsFinish) { return new GamePlayState(StateMachine); }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();


        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            //BGMManager.Current.Stop();
        }
    }
}