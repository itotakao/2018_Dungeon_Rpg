using UnityEngine.Assertions;

namespace Ito.GameState
{
    public abstract class GameStateMachine
    {
        public abstract GameState DefaultState { get; }

        public GameState CurrentState { get; private set; }

        public virtual void Start()
        {
            Transition(DefaultState);
        }

        public virtual void Update()
        {
            Assert.IsNotNull(CurrentState);

            foreach (var tf in CurrentState.TransitionFunctions)
            {
                if (!tf.mute)
                {
                    var nextState = tf.function();
                    if (nextState != null)
                    {
                        Transition(nextState);
                        break;
                    }
                }
            }

            CurrentState.OnStateUpdate();
        }

        public virtual void LateUpdate()
        {
            Assert.IsNotNull(CurrentState);

            CurrentState.OnStateLateUpdate();
        }

        void Transition(GameState state)
        {
            Assert.IsNotNull(state);

            if (CurrentState != null)
            {
                CurrentState.OnStateExit();
                CurrentState.OnStateDestroy();
            }

            CurrentState = state;

            CurrentState.OnStateInitialize();
            CurrentState.OnStateEnter();
        }
    }
}
