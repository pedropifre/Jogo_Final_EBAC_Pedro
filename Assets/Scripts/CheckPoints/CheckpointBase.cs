using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 1;
    public ParticleSystem particleSystemCP;

    private bool checkPointActivated= false;
    private string checkpointKey = "CheckPointKey";

    public bool _lastCheckpoint = false;
    public int nextLevelDex;

    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActivated && other.transform.tag == "Player" && !_lastCheckpoint)
        {
            CheckCheckPoint();
        }
        else if (!checkPointActivated && other.transform.tag == "Player" && _lastCheckpoint)
        {
            SaveManager.Instance.SaveLastLevel(nextLevelDex);
            SaveManager.Instance.SaveItens();
            StartCoroutine(LoadNextLevelDelay());
        }
    }
    IEnumerator LoadNextLevelDelay()
    {
        yield return new WaitForSeconds(3f);
        LoadNextLevel(2);
    }

    private void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level);
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
