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
        [SerializeField] private TextMeshProUGUI aiText;
        [SerializeField] private TextMeshProUGUI speakerName;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Transform playerResponseRoot;
        [SerializeField] private GameObject choiceButton;
        [SerializeField] private GameObject aiResponse;
        [SerializeField] private GameObject playerResponse;

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
            aiResponse.SetActive(!_playerConversant.IsChoosing());
            playerResponse.SetActive(_playerConversant.IsChoosing());
            speakerName.text = _playerConversant.GetCurrentConversantName();
            if (_playerConversant.IsChoosing())
                BuildChoiceList();
            else
            {
                aiText.text = _playerConversant.GetText();
                nextButton.gameObject.SetActive(_playerConversant.HasNext());
            }
            
             
        }

        private void BuildChoiceList()
        {
            foreach (Transform button in playerResponseRoot)
                Destroy(button.gameObject);
            if (_playerConversant.CurrentNode == _playerConversant.CurrentDialogue.GetRootNode() &&
                _playerConversant.CurrentDialogue.GetRootNode().IsPlayerSpeaking())
            {
                var choice = _playerConversant.CurrentNode;
                var button = Instantiate(choiceButton, playerResponseRoot);
                button.GetComponentInChildren<TextMeshProUGUI>().text = choice.GetText();
                button.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _playerConversant.SelectChoice(choice);
                });
            }
            else
            {
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
        }

        private void Next()
        {
            _playerConversant.Next();
        }
    }
}

