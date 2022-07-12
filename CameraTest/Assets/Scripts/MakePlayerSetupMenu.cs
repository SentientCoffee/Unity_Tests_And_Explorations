using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MakePlayerSetupMenu : MonoBehaviour {

    public GameObject playerSetupMenu;
    public PlayerInput playerInput;

    private void Awake() {
        var rootMenu = GameObject.Find("MainLayout");
        if(rootMenu == null) {
            Debug.LogError("Could not make player setup menu: Failed to find MainLayout layout group!");
            return;
        }

        var menu = Instantiate(playerSetupMenu, rootMenu.transform);
        playerInput.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
        menu.GetComponent<PlayerSetupMenu>().setPlayerIndex(playerInput.playerIndex);
    }

}
