using System;
using UnityEngine;
using RPG.Dialogue;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        private PlayerConversant _playerConversant;
        [SerializeField] private TextMeshProUGUI AIText;
        [SerializeField] private Button nextButton;
        [SerializeField] private Transform playerResponseRoot;
        [SerializeField] private GameObject choiceButton;
        [SerializeField] private GameObject AIResponse;
        [SerializeField] private GameObject PlayerResponse;

        private void Start()
        {
            _playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            nextButton.onClick.AddListener(Next);
            UpdateUI();
        }

        private void UpdateUI()
        {
            AIResponse.SetActive(!_playerConversant.IsChoosing());
            PlayerResponse.SetActive(_playerConversant.IsChoosing());
            if (_playerConversant.IsChoosing())
            {
                BuildChoiceList();
            }
            else
            {
                AIText.text = _playerConversant.GetText();
                nextButton.gameObject.SetActive(_playerConversant.HasNext());
            }
            
             
        }

        private void BuildChoiceList()
        {
            foreach (Transform button in playerResponseRoot)
                Destroy(button.gameObject);
            foreach (var choice in _playerConversant.GetChoices())
            {
                var button = Instantiate(choiceButton, playerResponseRoot);
                button.GetComponentInChildren<TextMeshProUGUI>().text = choice.GetText();
                button.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _playerConversant.SelectChoice(choice);
                    UpdateUI();
                });
            }
        }

        private void Next()
        {
            _playerConversant.Next();
            UpdateUI(); 
        }
    }
}

