using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour {
    [SerializeField] private int maxPlayers = 2;
    private List<PlayerConfiguration> _playerConfigs;
    public List<PlayerConfiguration> playerConfigurations { get { return _playerConfigs; } }

    public static PlayerConfigurationManager get { get; private set; }

    private void Awake() {
        if(get != null) {
            Debug.LogAssertion("Attempted to create new instance of PlayerConfigurationManager when one already exists!");
            return;
        }

        get = this;
        DontDestroyOnLoad(get);
        _playerConfigs = new List<PlayerConfiguration>();
    }

    public void setPlayerColour(int index, Material colour) {
        _playerConfigs[index].colour = colour;
    }

    public void readyPlayer(int index) {
        _playerConfigs[index].isReady = true;

        if(_playerConfigs.Count == maxPlayers && _playerConfigs.All(p => p.isReady)) {
            SceneManager.LoadScene(1);
        }

    }

    public void handlePlayerJoined(PlayerInput playerInput) {
        if(!_playerConfigs.Any(p => p.index == playerInput.playerIndex)) {
            Debug.LogFormat("Player {0} joined", playerInput.playerIndex);
            playerInput.transform.parent = transform;
            _playerConfigs.Add(new PlayerConfiguration(playerInput));
        }
    }

    public void handlePlayerLeft(PlayerInput playerInput) {
        if(_playerConfigs.Any(p => p.index == playerInput.playerIndex)) {
            Debug.LogFormat("Player {0} left", playerInput.playerIndex);
        }
    }
}

public class PlayerConfiguration {
    public PlayerInput input;
    public Material colour;
    public int index;
    public bool isReady;

    public PlayerConfiguration(PlayerInput playerInput) {
        input = playerInput;
        index = playerInput.playerIndex;
    }
}