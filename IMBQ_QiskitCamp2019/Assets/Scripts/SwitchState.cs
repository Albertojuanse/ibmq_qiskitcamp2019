using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchState : MonoBehaviour
{
    private TMPro.TextMeshProUGUI tmp;
    public Button btt;

    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        btt.onClick.AddListener(() => stop = true);

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
            tmp.text = Mathf.Round(Random.value) + "";

    }
}
