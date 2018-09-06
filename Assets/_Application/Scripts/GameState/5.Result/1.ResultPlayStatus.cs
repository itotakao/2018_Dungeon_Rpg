using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class ResultPlayState : State
    {
        public ResultPlayState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            //if (Result.IsRestart) { return new GameStartState(StateMachine); }
            //if (Result.IsExit) { return new MenuStartState(StateMachine); }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            //BGMManager.Current.PlayAsync("LM_1131_01U");
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            //BGMManager.Current.Stop();
        }
    }
}