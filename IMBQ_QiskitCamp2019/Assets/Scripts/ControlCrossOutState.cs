using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCrossOutState : MonoBehaviour
{
    public int index;
    public singleTableCrossOut table1;
    public singleTableCrossOut table2;


    // Start is called before the first frame update
    void Start()
    {
        Toggle myToggle = GetComponent<Toggle>();
        myToggle.onValueChanged.AddListener((b) =>
        {
            ToggleValueChanged(myToggle); 
        });
    }


    void ToggleValueChanged(Toggle myToggle)
    {
        table1.isCrossOutList[index] = !table1.isCrossOutList[index];
        table2.isCrossOutList[index] = !table2.isCrossOutList[index];
    }
}
