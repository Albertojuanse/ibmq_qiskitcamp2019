using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQBitFromGameData : MonoBehaviour
{
    public int index;
    private GameData _gameData = null;
    private GameData gameData {
        get {
            if (_gameData == null) {
                _gameData = FindObjectOfType<GameData>();
            }
            return _gameData;
        }
    }

    private QBitManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<QBitManager>();
        manager.QBase = gameData.selectedBitsInfo[index].qBase;
        manager.QValue = gameData.selectedBitsInfo[index].qValue;
    }

}
