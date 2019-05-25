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
        selectedBitsInfo = new List<QBitInfo>();

        for (int i = 0; i < qBitsToSelect; i++) {
            selectedBitsInfo.Add(new QBitInfo());
            if (i >= 5) {
                selectedBitsInfo[i].SetRandom();
            }
        }

        GetComponent<Animator>().SetTrigger("Start");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
