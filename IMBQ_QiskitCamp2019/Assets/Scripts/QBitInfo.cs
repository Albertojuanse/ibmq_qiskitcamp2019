using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QBitInfo 
{

    public string qBase;
    public string qValue;

    public void Set(string qBitBase, string qBitValue) {
        qBase = qBitBase;
        qValue = qBitValue;
    }

    public void SetRandom() {
        qBase = UnityEngine.Random.value < 0.5f ? "X" : "Z";
        qValue = UnityEngine.Random.value < 0.5f ? "0" : "1";
    }

}
