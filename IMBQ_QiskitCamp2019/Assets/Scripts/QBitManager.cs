﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QBitManager : MonoBehaviour
{
    public QBitStateImages states;
    public Image bgImage;
    public Image hiddenImage;
    public TMPro.TextMeshProUGUI text;
    public Mask mask;

    [Space(10)]
    public string QBase = "";
    public string QValue = "";

    [Space(10)]
    public bool hidden = false;
    public bool stablished => !string.IsNullOrEmpty(QBase) && !string.IsNullOrEmpty(QValue);

    // Start is called before the first frame update
    void Start()
    {
        hiddenImage.sprite = states.darkQBit;
    }

    // Update is called once per frame
    void Update() {
        hiddenImage.gameObject.SetActive(hidden);

        if (stablished) {

            if (QBase.ToUpper() == "Z") {
                bgImage.sprite = QValue == "1" ? states.one : states.zero;
            } else {
                bgImage.sprite = QValue == "1" ? states.left : states.right;
            }
            text.text = QValue + QBase.ToUpper();
        }
        bgImage.gameObject.SetActive(stablished && !hidden);
        text.gameObject.SetActive(stablished);
    }
}
