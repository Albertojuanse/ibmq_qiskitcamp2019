using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcatenateBobAxes : MonoBehaviour {

    private TMPro.TextMeshProUGUI tmp;
    public string pre;

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
    void Start() {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        tmp.text = pre;
        foreach (QBitInfo qBit in gameData.bobReadQBitsInfo) {
            tmp.text += $" {qBit.qBase}";
        }
    }
}
