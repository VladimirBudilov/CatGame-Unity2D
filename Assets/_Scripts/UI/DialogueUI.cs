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
        [SerializeField] private TextMeshProUGUI SpeakerName;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Transform playerResponseRoot;
        [SerializeField] private GameObject choiceButton;
        [SerializeField] private GameObject AIResponse;
        [SerializeField] private GameObject PlayerResponse;

        private void Start()
        {
            _playerConversant = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            nextButton.onClick.AddListener(Next);
            quitButton.onClick.AddListener(_playerConversant.Quit);
            _playerConversant.onConversationUpdated += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            gameObject.SetActive(_playerConversant.IsActive());
            if (!_playerConversant.IsActive())
                return;
            AIResponse.SetActive(!_playerConversant.IsChoosing());
            PlayerResponse.SetActive(_playerConversant.IsChoosing());
            if (_playerConversant.IsChoosing())
            {
                BuildChoiceList();
                SpeakerName.text = _playerConversant.GetCurrentSpeakerName();
            }
            else
            {
                AIText.text = _playerConversant.GetText();
                nextButton.gameObject.SetActive(_playerConversant.HasNext());
                SpeakerName.text = _playerConversant.GetCurrentSpeakerName();
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
                });
            }
        }

        private void Next()
        {
            _playerConversant.Next();
        }
    }
}

