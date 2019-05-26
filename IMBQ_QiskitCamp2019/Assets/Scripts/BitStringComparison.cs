using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitStringComparison : MonoBehaviour
{

    int c1 = 0;  // counter between alice and bob
    int c2 = 0;  // counter between alice and eve
    int i = 0;
    int j = 0;


    // bitstrings: stringA Alice stringB Bob stringE Eve
    void BitStrings(string stringA, string stringB, string stringE)
    {


        foreach (char item1 in stringA)
        {
            if (item1 == stringB[i])
            {
                c1++;
            }
            i++;
        }

        foreach (char item1 in stringA)
        {
            if (item1 == stringE[j])
            {
                c2++;
            }
            j++;
        }
        //comparison between counters for game ending choice
        int a = (int) Mathf.Floor(stringA.Length / 2); //probability of guessing half of the bit string is (3/4)^(N/2)
        if (c2 >= a || c2 >= c1 )
            {
             //eva gana no sé como poner esto   
            }
        else
            {
            //ganan alice y bob
            }

    }


}


