using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    public int AliceBobWins = 0;
    public int EvaWins = 0;
    public int Aborted = 0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
