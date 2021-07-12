using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _levelText;

    public Character Character { get; private set; }

    public void UpdateView()
    {
        _nameText.text = Character.Name.ToString();
        _healthText.text = Character.Health.ToString();
        _levelText.text = Character.Level.ToString();
    }

    public void Create(Character character)
    {
        Character = character;
        UpdateView();
    }
}
