using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour
{

    public TextMeshProUGUI uiTextname;
    private void Start()
    {
        SaveManager.Instance.FileLoaded += OnLoad;
    }

    public void OnLoad(SaveSetup saveSetup)
    {
        uiTextname.text = "Play " + (saveSetup.lastLevel + 1);
    }

    private void OnDestroy()
    {
        SaveManager.Instance.FileLoaded -= OnLoad;
    }
}
