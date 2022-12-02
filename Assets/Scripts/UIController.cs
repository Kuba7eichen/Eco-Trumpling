using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI loseText1;
    [SerializeField] TextMeshProUGUI loseText2;
    // Start is called before the first frame update
    void Start()
    {
        loseText1.enabled = false;
        loseText2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMoneyText(int money)
    {
        moneyText.text = "$" + money + "M";
    }

    public void EnableLosingText()
    {
        loseText1.enabled = true;
        loseText2.enabled = true;

    }
}
