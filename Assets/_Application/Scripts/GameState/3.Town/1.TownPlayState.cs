using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ito.GameState;

namespace Ito
{
    public class TownPlayState : State
    {      
        public TownPlayState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            //if (isFinish) { return new TownPlayState(StateMachine); }

            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}