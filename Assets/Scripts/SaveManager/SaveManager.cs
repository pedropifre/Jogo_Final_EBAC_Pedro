using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using GeneralUtils.Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded ;
    public Texture mainTexture;

    
    

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Pedro";
    }

    private void Start()
    {
        Invoke(nameof(Load),.3f);
        
    }


    #region Save

    [NaughtyAttributes.Button]
    private void Save()
    {
        SaveSetup setup = new SaveSetup();
        setup.playerName = "Pedro";

        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.health = Itens.ItemManager.Instance.GetByType(Itens.ItemType.LIFE_PACK).soInt.value;
        _saveSetup.texturePlayer = Player.Instance.ReturnTexture();

        Save();
    }

    public void SaveCheckpoint(int checkpointNumber)
    {
        _saveSetup.checkPoint = checkpointNumber;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        Save();
    }

    #endregion
    
    private void SaveFile(string json)
    {
        

        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
        }
        Debug.Log(_path);
        File.WriteAllText(_path, json);
    }

    public void UppdateMenu()
    {
        Load();
    }
    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }

        FileLoaded.Invoke(_saveSetup);
        if (_saveSetup.texturePlayer == null)
        {
            _saveSetup.texturePlayer = mainTexture;
            Save();
        }

    }
 

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
    
    [NaughtyAttributes.Button]
    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }
}

[System.Serializable]

public class SaveSetup
{
    public int lastLevel;
    public float coins;
    public float health;
    public string playerName;
    public Texture texturePlayer;
    public int checkPoint;
}