using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public int Hint, currentHint = 0; 
    int usedHint;
    public Text hintText;

    public List<Dragdrop> list = new List<Dragdrop>();
    public GameObject[] showNumber;
    bool useHint;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hint"))
        {
            currentHint = PlayerPrefs.GetInt("Hint");
        }
        if (PlayerPrefs.HasKey("usedHint"))
        {
            usedHint = PlayerPrefs.GetInt("usedHint");
        }

        UpdateHint();
    }

    // Update is called once per frame
    void Update()
    {
        hintText.text = currentHint.ToString();
    }

    public void UpdateHint()
    {
        currentHint += Hint;
        PlayerPrefs.SetInt("Hint", currentHint);
        hintText.text = currentHint.ToString();
    }

    public void UseHintJigsaw()
    {
        int randomIndex = Random.Range(0, list.Count);

        if (currentHint > 0)
        {
            if (list[randomIndex].onTempel)
            {
                list.Remove(list[randomIndex]);
                UseHintJigsaw();
            }
            else
            {
                list[randomIndex].onPos = true;
                list[randomIndex].OnMouseUp();
                list.Remove(list[randomIndex]);
                currentHint--;
                usedHint++;
            }
            
        }
        else
        {
            currentHint = 0;
            Debug.Log("The list is empty: ");
        }

        PlayerPrefs.SetInt("Hint", currentHint);
        PlayerPrefs.SetInt("usedHint", usedHint);
    }

    public void UseHintSliding()
    {
        if(currentHint > 0)
        {
            if (!useHint)
            {
                foreach (GameObject number in showNumber)
                {
                    number.SetActive(true);
                }
                currentHint--;
                useHint = true;
            }
            else
                Debug.Log("you already used hint");

        }
        else
        {
            currentHint = 0;
        }

        PlayerPrefs.SetInt("Hint", currentHint);
        PlayerPrefs.SetInt("usedHint", usedHint);

    }
}
