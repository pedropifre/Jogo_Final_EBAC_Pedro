using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;
using Pedro.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public Player player;
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;
    public List<GameObject> checkPointList;

    private void Start()
    {
        Init();
        InitGame();
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
        Debug.Log("init game");
        foreach (var i in checkPointList)
        {
            if (i.GetComponent<CheckpointBase>().checkPointNumber == (int)SaveManager.Instance.Setup.checkPoint)
            {
                Player.Instance.SpawnPlayerCheckpoint(i.transform);
            }
        }
        //SaveManager.Instance.SpawnPlayerCheckpoint();
    }
}
