using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;
using Pedro.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();

        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSE, new StateBase());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());

        stateMachine.SwitchState(GameStates.INTRO);
    }

    public void InitGame()
    {

    }
}
