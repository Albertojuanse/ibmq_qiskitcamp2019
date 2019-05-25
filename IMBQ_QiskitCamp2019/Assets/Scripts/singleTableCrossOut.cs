using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singleTableCrossOut : MonoBehaviour
{

    public List<Image> crossOutImageList = new List<Image>(5);
    public List<bool> isCrossOutList = new List<bool>(5);



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < isCrossOutList.Count; i++)
        {
            if (isCrossOutList[i])
                crossOutImageList[i].gameObject.SetActive(true);
            else
                crossOutImageList[i].gameObject.SetActive(false);
        }
    }
}
