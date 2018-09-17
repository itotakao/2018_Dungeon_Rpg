using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class TitleState : State
    {
        public TitleState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (Input.GetKeyDown(KeyCode.S) || TitleUI.IsOnButton)
            {
                return new GameStartState(StateMachine);
            }

            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            TitleUI.Show(true);
            GameUI.Show(false);

            PlayerManager.Initilize();
            LogManager.ClerText();

            EventUI.Reset();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}