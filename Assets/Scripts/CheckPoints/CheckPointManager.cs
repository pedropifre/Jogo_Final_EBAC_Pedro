using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPointKey = 0;
    public List<CheckpointBase> checkpoints; 

    public bool hasCheckPoint()
    {
        return lastCheckPointKey > 0;
    }

    public void SaveLastCheckPoint(int i)
    {
        if (i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
        }
    }

    public Vector3 GetPosLastCP()
    {
        var checkpoint= checkpoints.Find(i => i.key == lastCheckPointKey);
        return checkpoint.transform.position;
    }
}
