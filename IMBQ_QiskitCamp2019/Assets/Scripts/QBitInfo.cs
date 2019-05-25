using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBitInfo 
{
    public string qBase;
    public string qValue;

    public void Set(string qBitBase, string qBitValue) {
        qBase = qBitBase;
        qValue = qBitValue;
    }

    public void SetRandom() {
        qBase = Random.value < 0.5f ? "X" : "Z";
        qValue = Random.value < 0.5f ? "0" : "1";
    }

}
