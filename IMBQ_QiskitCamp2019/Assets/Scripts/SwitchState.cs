﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchState : MonoBehaviour
{
    private TMPro.TextMeshProUGUI tmp;
    public Button btt;

    private bool stop = false;

    public string state1 = "0";
    public string state2 = "1";

    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        btt.onClick.AddListener(() => Invoke("Stop", delay));
    }

    public void Stop() {
        stop = true;
        tmp.text = UnityQASM.unityQASM.GetRandomBool() ? state1 : state2;
    }
    public void Restart() {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!stop)
            tmp.text = Random.value < 0.5f ? state1 : state2;

    }
}
