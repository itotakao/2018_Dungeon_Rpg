using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class TutorialStartState : State
    {
        public TutorialStartState(StateMachine stateMachine) : base(stateMachine)
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