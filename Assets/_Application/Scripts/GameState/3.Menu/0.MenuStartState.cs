using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class MenuStartState : State
    {
        public MenuStartState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            //if (Menu.IsOnButton)
            //{
            //    return new GameStartState(StateMachine);
            //}

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