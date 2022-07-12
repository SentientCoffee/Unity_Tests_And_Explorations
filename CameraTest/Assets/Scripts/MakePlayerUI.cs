using UnityEngine;

public class MakePlayerUI : MonoBehaviour {
    public GameObject player;
    public GameObject playerUIPanel;

    private void Awake() {
        var rootCanvas = GameObject.Find("PlayerUILayout");
        if(rootCanvas == null) {
            Debug.LogError("Could not make player UI: Failed to find PlayerUILayout canvas!");
            return;
        }

        var ui = Instantiate(playerUIPanel, rootCanvas.transform);
        player.GetComponent<PlayerCameraAndUI>().playerUIPanel = ui.GetComponent<RectTransform>();
        player.GetComponent<PlayerCameraAndUI>().screenDimensions = new Vector2(Screen.width, Screen.height);

    }
}