using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterDatabase characterDB;

    [SerializeField]
    private Animator artworkAnim;

    [SerializeField]
    private SpriteRenderer artworkSprite;

    public int selectedOption = 0;

    private void Start()
    {
        AudioManager.instance.PlaySFX("Play");
        if (!PlayerPrefs.HasKey("selectedOptions"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        AudioManager.instance.PlayMusic("Theme");


    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkAnim.runtimeAnimatorController = character.characterAnim;
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOptions");
    }

}
