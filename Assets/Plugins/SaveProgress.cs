using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;


[System.Serializable]

public class PlayerInfo
{

    public int Coins;
    public int LastLvl;
}
public class SaveProgress : MonoBehaviour
{
    public static SaveProgress Instance;

    public PlayerInfo PlayerInfo;

    [SerializeField]private TMP_Text _playerInfoText;



    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        LoadExtern();
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo.Coins+ "\n"+ PlayerInfo.LastLvl;
    }
    private void Update()
    {


        if(Input.GetKeyUp(KeyCode.I))
        {
            PlayerInfo.Coins++;


        }
#if UNITY_WEBGL

        if (Input.GetKeyDown(KeyCode.P)) {
            Save();
            Debug.Log("IamSave");
        }
    }
#endif
}
