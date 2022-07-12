using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Mover))]
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer _playerMesh = null;
    private PlayerConfiguration _playerConfig;
    private PlayerControls _controls;
    private Mover _mover;

    private void Awake() {
        _mover = GetComponent<Mover>();
        _controls = new PlayerControls();
    }

    public void initPlayer(PlayerConfiguration config) {
        _playerConfig = config;
        _playerMesh.material = config.colour;
        _playerConfig.input.onActionTriggered += onActionTriggered;
    }

    private void onActionTriggered(CallbackContext context) {
        if(context.action.name == _controls.PlayerMovement.Movement.name) {
            onMove(context);
        }
    } 

    public void onMove(CallbackContext context) {
        if(_mover != null) _mover.inputVector = context.ReadValue<Vector2>();
    }
}
