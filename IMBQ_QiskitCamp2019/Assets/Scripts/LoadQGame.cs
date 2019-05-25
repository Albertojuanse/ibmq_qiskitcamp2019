using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadQGame : MonoBehaviour
{
    public Button btt;

    // Start is called before the first frame update
    void Start()
    {
        btt.onClick.AddListener(() => SceneManager.LoadScene("QGame"));
    }
}


