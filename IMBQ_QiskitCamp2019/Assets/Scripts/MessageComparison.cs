using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageComparison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string CompareStrings(string string1, string string2)
    {
        string string3 = "";
        int  i = 0;
        foreach (char item1 in string1)
        {
            if (item1 == string2[i]) {
                string3 += "0";
            } else {
                string3 += "1";
            }
            i++;
        }

        return string3;
    }
}

