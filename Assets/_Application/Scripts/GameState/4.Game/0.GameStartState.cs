﻿using System.Collections;
using System.Collections.Generic;
using Ito.GameState;
using UnityEngine;

namespace Ito
{
    public class GameStartState : State
    {
        bool isFinish = false;

        public GameStartState(StateMachine stateMachine) : base(stateMachine)
        {
            TransitionFunctions.Add(new TransitionFunction(Transition));
        }

        State Transition()
        {
            if (isFinish) { return new GameRefleshState(StateMachine); }
            return null;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            GameManager.Reflesh();

            TitleScene.Show(false);
            TownScene.Show(false);
            GameScene.Show(true);

            BattleUI.Show(false);

            FadeManager.isFadeIn = true;

            // TODO : カプセル化
            BattleUI.PlayerNameText.text = PlayerManager.GetName();

            isFinish = true;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            isFinish = false;
        }
    }
}