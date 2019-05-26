using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAliceAxesOnCrossout : MonoBehaviour
{

    private singleTableCrossOut table;

    private GameData _gameData = null;
    private GameData gameData {
        get {
            if (_gameData == null) {
                _gameData = FindObjectOfType<GameData>();
            }
            return _gameData;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        table = GetComponent<singleTableCrossOut>();
        for ( int i = 0; i < 5; i++) {
            table.texts[i].text = gameData.selectedBitsInfo[i].qBase;
        }

    }

}
