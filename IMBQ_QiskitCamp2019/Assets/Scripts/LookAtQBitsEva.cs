using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtQBitsEva : MonoBehaviour
{

    public bool isEva = true;

    public Animator animator;
    [Space(10)]
    public Button btt;
    public TMPro.TextMeshProUGUI tmp;
    public float delay;


    [Space(10)]
    public Image reader;
    public Sprite readX;
    public Sprite readZ;

    [Space(10)]
    private int currentIndex;
    public List<QBitManager> managers;

    private List<QBitInfo> referenceQBits;

    private GameData _gameData = null;
    private GameData gameData {
        get {
            if (_gameData == null) {
                _gameData = FindObjectOfType<GameData>();
            }
            return _gameData;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        btt.onClick.AddListener(() => Invoke("OnStateCollapse", delay));

        referenceQBits = gameData.evaReadQBitsInfo.Count > 0 ? gameData.evaReadQBitsInfo : gameData.selectedBitsInfo;

    }

    private void OnStateCollapse() {
        //string selectedAxis = currentIndex >= 5 ? Random.value < 0.5f ? "x" : "z" : tmp.text.ToLower();
        string selectedAxis = currentIndex >= 5 ? UnityQASM.unityQASM.GetRandomBool() ? "x" : "z" : tmp.text.ToLower();
        bool isX = selectedAxis == "x";
        bool currentBaseIsX = referenceQBits[currentIndex].qBase.ToLower() == "x";
        bool readSuccess = isX == currentBaseIsX;

        QBitInfo qBitInfo = new QBitInfo();
        if (!readSuccess) {
            qBitInfo.SetRandom();
            qBitInfo.qBase = tmp.text;
        } else {
            qBitInfo = referenceQBits[currentIndex];
            if (isEva) {
                gameData.evaSuccessCount++;
            } else {
                gameData.bobSuccessCount++;
            }
        }

        if (isEva) {
            gameData.evaReadQBitsInfo.Add(qBitInfo);
        } else {
            gameData.bobReadQBitsInfo.Add(qBitInfo);
        }

        tmp.GetComponent<SwitchState>().Restart();


        if (currentIndex < 5) {
            managers[currentIndex].QValue = qBitInfo.qValue;
            managers[currentIndex].QBase = qBitInfo.qBase;
            reader.sprite = isX ? readX : readZ;
            animator.SetTrigger("Read");
        }
        currentIndex++;
        if (currentIndex == 5) {
            for (int i = 0; i < 15; i++) {
                OnStateCollapse();
            }
        }
    }
}
