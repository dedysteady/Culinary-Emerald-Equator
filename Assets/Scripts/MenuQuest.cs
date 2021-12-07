using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuQuest : MonoBehaviour
{
    int coin, hint, buyHint, usedHint;
    GameObject[] buttonQuest;
    public Text usedHintText, buyHintText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("usedHint"))
        {
            usedHint = PlayerPrefs.GetInt("usedHint");
        }
        if (PlayerPrefs.HasKey("buyHint"))
        {
            buyHint = PlayerPrefs.GetInt("buyHint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        usedHintText.text = usedHint.ToString() + "/ 10";
        buyHintText.text = buyHint.ToString() + "/ 5";
    }

    public void PriceHint(int reward)
    {
        switch (reward)
        {
            case 1:
                Debug.Log("Dapat 100 coin");
                coin = 100;
                break;

            case 2:
                Debug.Log("Dapat 500 coin");
                coin = 500;
                break;

            case 3:
                Debug.Log("Dapat 5 Hint");
                hint = 5;
                break;

            case 4:
                Debug.Log("Dapat 1000 coin");
                coin = 1000;
                break;

            case 5:
                Debug.Log("Dapat 500 coin");
                coin = 500;
                break;
        }
    }

    void checkQuest()
    {
        if (usedHint == 10)
        {
            
        }

        if (buyHint == 5)
        {

        }
    }
}
