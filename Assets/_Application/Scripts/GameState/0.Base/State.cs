using Ito.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;
using Battle;
using Town;

namespace Ito
{
    public abstract class State : GameState<StateMachine>
    {
        public CardManager CardManager { get { return CardManager.Current; } }

        public TitleScene TitleScene { get { return TitleScene.Current; } }
        public TownScene TownScene { get { return TownScene.Current; } }
        public GameScene GameScene { get { return GameScene.Current; } }
        public ResultScene ResultScene { get { return ResultScene.Current; } }


        public BattleUI BattleUI { get { return BattleUI.Current; } }
        public MenuUI MenuUI { get { return MenuUI.Current; } }

        public FadeManager FadeManager { get { return FadeManager.Current; } }
        public TurnManager TurnManager { get { return TurnManager.Current; } }
        public GameManager GameManager { get { return GameManager.Current; } }
        public PlayerManager PlayerManager { get { return PlayerManager.Current; } }
        public BattleManager BattleManager { get { return BattleManager.Current; } }
        public TextManager TextManager { get { return TextManager.Current; } }

        enum SwitchToState { None, Title, Battle, Town };
        SwitchToState switchTo = SwitchToState.None;

        public State(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Switch));
        }

        State Switch()
        {
            switch (switchTo)
            {
                case SwitchToState.Title: return new TutorialStartState(StateMachine);
                case SwitchToState.Town: return new TownStartState(StateMachine);
                case SwitchToState.Battle: return new GameStartState(StateMachine);
            }

            return null;
        }

        public override void OnStateEnter()
        {
            Debug.Log("State : " + GetType().Name);
        }

        public override void OnStateExit()
        {
        }

        public override void OnStateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.R)) { ReloadScene(); }

            if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

            if (GameManager.IsSwitchToTown) { switchTo = SwitchToState.Town; }
            if (GameManager.IsSwitchToBattle) { switchTo = SwitchToState.Battle; }

            //if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            //{
            //    if (Input.GetKeyDown(KeyCode.F))
            //    {
            //        UDP_sender.Current.onStart = true;
            //    }

            //    if (Input.GetKeyDown(KeyCode.H))
            //    {
            //        UDP_sender.Current.onHome = true;
            //    }
            //}

            //if (Settings.Debug.UseDebugSkipCommand)
            //{
            //    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            //    {
            //        if (Input.GetKeyDown(KeyCode.Alpha1))
            //        {
            //            SetRound(1);
            //            skipTo = SkipToState.Tutorial;
            //        }
            //        else if (Input.GetKeyDown(KeyCode.Alpha2))
            //        {
            //            SetRound(1);
            //            skipTo = SkipToState.Opening;
            //        }
            //        else if (Input.GetKeyDown(KeyCode.Alpha3))
            //        {
            //            SetRound(1);
            //            skipTo = SkipToState.Duel1;
            //        }
            //        else if (Input.GetKeyDown(KeyCode.Alpha4))
            //        {
            //            SetRound(2);
            //            skipTo = SkipToState.Duel2;
            //        }
            //        else if (Input.GetKeyDown(KeyCode.Alpha5))
            //        {
            //            SetRound(3);
            //            skipTo = SkipToState.FinalDuel;
            //        }
            //        else if (Input.GetKeyDown(KeyCode.Alpha6))
            //        {
            //            SetRound(4);
            //            skipTo = SkipToState.Result;
            //        }

            //        if (skipTo != SkipToState.None)
            //        {
            //            Keeper.ResetKeeperRootTransform();
            //        }
            //    }
            //}
        }

        protected void SkipToKickRound(int round)
        {
            //if (round <= 1)
            //{
            //    SetRound(1);
            //    skipTo = SkipToState.Duel1;
            //}
            //else if (round == 2)
            //{
            //    SetRound(2);
            //    skipTo = SkipToState.Duel2;
            //}
            //else
            //{
            //    SetRound(3);
            //    skipTo = SkipToState.FinalDuel;
            //}

            //if (skipTo != SkipToState.None)
            //{
            //    Keeper.ResetKeeperRootTransform();
            //}
        }

        void SetRound(int round)
        {
            //for (var r = 1; r < round; r++)
            //{
            //    if (Player.GetScore(r) == null)
            //    {
            //        Player.SetScore(r, new PlayerScore()
            //        {
            //            IsGoal = Random.value > 0.5f,
            //            Course = Random.value,
            //            Timing = Random.value,
            //            Speed = Random.value,
            //        });
            //    }
            //}

            //for (var r = round; r <= Player.TotalRounds; r++)
            //{
            //    Player.SetScore(r, null);
            //}
        }

        protected void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}