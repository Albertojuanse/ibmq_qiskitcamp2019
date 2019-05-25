using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customNumRows : MonoBehaviour
{
    public int rowsToShow = 3;
    public List<TMPro.TextMeshProUGUI> rows = new List<TMPro.TextMeshProUGUI>(5);

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rowsToShow);
        if(rowsToShow >= 1 && rowsToShow <= 5) {
            for (int i = 0; i < rows.Count; i++)
            {
                rows[i].gameObject.SetActive(i < rowsToShow);
            }
        }
    }
}
