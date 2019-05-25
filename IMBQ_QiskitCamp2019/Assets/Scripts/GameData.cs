using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public int qBitsToSelect = 20;
    public List<QBitInfo> selectedBitsInfo;


    // Start is called before the first frame update
    void Start()
    {
        selectedBitsInfo = new List<QBitInfo>(20);

        for (int i = 5; i < selectedBitsInfo.Count; i++) {
            selectedBitsInfo[i].SetRandom();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
