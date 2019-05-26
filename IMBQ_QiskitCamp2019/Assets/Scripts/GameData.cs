using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public int qBitsToSelect = 20;
    public List<QBitInfo> selectedBitsInfo;
    public List<QBitInfo> evaReadQBitsInfo;
    public List<QBitInfo> bobReadQBitsInfo;

    public int evaSuccessCount = 0;
    public int bobSuccessCount = 0;

    // Start is called before the first frame update
    void Awake()
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
