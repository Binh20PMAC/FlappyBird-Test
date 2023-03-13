using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManger : MonoBehaviour
{
    [SerializeField]
    private CharacterDatabase characterDB;

    [SerializeField]
    private TMP_Text nameText;

    [SerializeField]
    private Animator artworkAnim;

    [SerializeField]
    private SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOptions"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        AudioManager.instance.PlayMusic("Menu");
        
    }

    public void NextOption()
    {
        selectedOption++;
        AudioManager.instance.PlaySFX("Tap");
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
        
    }

    public void BackOption()
    {
        selectedOption--;
        AudioManager.instance.PlaySFX("Tap");
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }    
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkAnim.runtimeAnimatorController = character.characterAnim;
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOptions"); 
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOptions", selectedOption);   
    }
}
