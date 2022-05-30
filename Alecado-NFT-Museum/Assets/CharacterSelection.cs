using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selecterCharacter = 0;
    public Text chrName;
    public string playerRole;
    public Dropdown dropdown;
    public string name;

    void Start()
    {
        
    }

    public void NextCh()
    {
        characters[selecterCharacter].SetActive(false);
        selecterCharacter = (selecterCharacter + 1) % characters.Length;
        characters[selecterCharacter].SetActive(true);
    }
    public void PrevCh()
    {
        characters[selecterCharacter].SetActive(false);
        selecterCharacter--;
        if (selecterCharacter < 0)
        {
            selecterCharacter += characters.Length;
        }
        characters[selecterCharacter].SetActive(true);
    }
    public void Play()
    {
        PlayerPrefs.SetInt("selectedCharacter", selecterCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void SetName()
    {
        if (chrName.text == "")
        {
            name = chrName.text;
        }
        else
        {
            name = chrName.text;
            PlayerPrefs.SetString("characterName", chrName.text);
        }
    }
    public void SetRole()
    {
        Debug.Log(" value: " + dropdown.value);
        if(dropdown.value == 1 )
        {
            playerRole = "Visitor";
            PlayerPrefs.SetString("playerRole", playerRole);
        }
        if(dropdown.value == 2)
        {
            playerRole = "Museum Owner";
            PlayerPrefs.SetString("playerRole", playerRole);
        }
    }
}
