using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPanel : MonoBehaviour
{

    public Animator globalAnimator;

    [Space(10)]
    public Button addBtt;
    public SwitchState switchState1;
    public SwitchState switchState2;
    public TMPro.TextMeshProUGUI QBaseText;
    public TMPro.TextMeshProUGUI QValueText;

    public List<QBitManager> managers;

    public float delay = 0;
    private int currentIndex = 0;

    private void Start() {
        addBtt.onClick.AddListener(() => Invoke("StablishNext", delay));
    }

    private void StablishNext() {
        QBitManager qBitManager = managers[currentIndex];
        qBitManager.QBase = QBaseText.text;
        qBitManager.QValue = QValueText.text;

        QBaseText.text = "";
        QValueText.text = "";

        switchState1.Restart();
        switchState2.Restart();
        currentIndex++;

        globalAnimator.SetInteger("QbitsSelected", currentIndex);
    }

}
