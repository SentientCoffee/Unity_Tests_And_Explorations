using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSetupMenu : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _titleText = null;
    [SerializeField] private GameObject _menuPanel      = null;
    [SerializeField] private GameObject _readyPanel     = null;
    [SerializeField] private Button _readyButton        = null;


    private int _playerIndex;
    private float _ignoreInputTime = 1.5f;
    private bool _inputEnabled = true;

    public void setPlayerIndex(int value) {
        _playerIndex = value;
        _titleText.SetText("Player " + (_playerIndex + 1).ToString());
        _ignoreInputTime = Time.time + _ignoreInputTime;
        _inputEnabled = false;
    }

    public void setPlayerColour(Material colour) {
        if(!_inputEnabled) return;

        PlayerConfigurationManager.get.setPlayerColour(_playerIndex, colour);
        _menuPanel.SetActive(false);
        _readyPanel.SetActive(true);
        _readyButton.Select();
    }

    public void readyPlayer() {
        if(!_inputEnabled) return;
        PlayerConfigurationManager.get.readyPlayer(_playerIndex);
        _readyButton.gameObject.SetActive(false);
    }

    private void Update() {
        if(Time.time > _ignoreInputTime) _inputEnabled = true;
    }


}
