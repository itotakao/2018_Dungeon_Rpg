using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ito.GameState;

namespace Ito
{
    public class TownRefreshState : State
    {
        public TownRefreshState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //return new TutorialStartState(StateMachine);
            }

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