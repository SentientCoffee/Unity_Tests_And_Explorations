using UnityEngine;

public class InitializeLevel : MonoBehaviour {
    [SerializeField] private Transform[] _playerSpawns = null;
    [SerializeField] private GameObject _playerPrefab = null;
    [SerializeField] private CameraSplitter _cameraSplitter = null;

    private void Start() {
        var playerConfigs = PlayerConfigurationManager.get.playerConfigurations.ToArray();
        for(int i = 0; i < playerConfigs.Length; i++) {
            var player = Instantiate(_playerPrefab, _playerSpawns[i].position, _playerSpawns[i].rotation, transform);
            player.GetComponent<PlayerInputHandler>().initPlayer(playerConfigs[i]);
            _cameraSplitter.addCameras(player.GetComponent<PlayerCameraAndUI>());
        }
    }
}
