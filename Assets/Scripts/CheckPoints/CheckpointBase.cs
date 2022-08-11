using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 1;
    public ParticleSystem particleSystemCP;

    private bool checkPointActivated= false;
    private string checkpointKey = "CheckPointKey";

    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActivated && other.transform.tag == "Player")
        {
            CheckCheckPoint();
        }
    }

    public void CheckCheckPoint()
    {
        TurnOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
        particleSystemCP.Play();
    }
    private void TurnOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.black);
    }

    private void SaveCheckPoint()
    {
        //if (PlayerPrefs.GetInt(checkpointKey, 0) > key)
        //{ 
        //    PlayerPrefs.SetInt(checkpointKey, key);
        //}

        CheckPointManager.Instance.SaveLastCheckPoint(key);
        checkPointActivated = true;
    }
}
