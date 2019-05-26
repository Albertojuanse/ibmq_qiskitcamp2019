using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComparisonConfirmation : MonoBehaviour
{


    public singleTableCrossOut table1;
    public singleTableCrossOut table2;

    public UnityEvent OnConfirmation = new UnityEvent();
    private bool confirmed = false;

    // Update is called once per frame
    void Update()
    {
        if (confirmed) return;

        for (int i = 0; i < 5; i++) {
            if (!(table1.texts[i].text.ToLower() == table2.texts[i].text.ToLower() && !table1.isCrossOutList[i] ||
                  table1.texts[i].text.ToLower() != table2.texts[i].text.ToLower() && table1.isCrossOutList[i])) {
                return;
            }
        }
        confirmed = true;
        OnConfirmation.Invoke();
    }
}
