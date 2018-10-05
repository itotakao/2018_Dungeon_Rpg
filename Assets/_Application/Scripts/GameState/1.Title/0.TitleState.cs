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
            if (Input.GetKeyDown(KeyCode.S) || TitleScene.IsOnButton)
            {
                return new TownStartState(StateMachine);
            }

            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            TitleScene.Show(true);
            TownScene.Show(false);
            GameScene.Show(false);

            PlayerManager.Initilize();
            TextManager.ClerLog();

            BattleManager.Reflesh();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}