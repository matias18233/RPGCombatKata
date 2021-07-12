using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IGameView
{
    [SerializeField] InputField origin;
    [SerializeField] InputField target;
    [SerializeField] Button btnAttack;
    [SerializeField] List<CharacterView> charactersViews;
    [SerializeField] GameObject characterViewPrefab;
    [SerializeField] Transform panel;

    GamePresenter gamePresenter;

    private void Start()
    {
        gamePresenter = new GamePresenter(this);
        btnAttack.onClick.AddListener(Attack);
    }


    //UI botones
    public void Attack()
    {
        gamePresenter.Attack(origin.text, target.text);
    }

    public void Heal()
    {
        gamePresenter.Heal(origin.text, target.text);
    }


    //Interfaz
    public void OnCreate(Character character)
    {
        // Busca un panel vacío en la vista
        CharacterView characterView = charactersViews.Find(cV => cV.Character == null);

        //Menos vistas que personaje
        if (characterView == null)
        {
            // Instancia una nueva vista en caso de que queden todas ocupadas
            GameObject gO = GameObject.Instantiate(characterViewPrefab);
            gO.transform.SetParent(panel);
            characterView = gO.GetComponent<CharacterView>();
            charactersViews.Add(characterView);
        }

        //mas vistas
        characterView.Create(character);
    }

    public void OnUpdate(Character character)
    {
        CharacterView characterView = charactersViews.Find(cV => cV.Character == character);
        if (characterView == null) return; // No existe una vista para el personaje

        characterView.UpdateView();
    }
}
