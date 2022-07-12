using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskTest : MonoBehaviour
{
    public GameObject gaming = null;
    public GameObject notGaming = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Gaming layer: {gaming.layer}");
        Debug.Log($"Not gaming layer: {notGaming.layer}");

        LayerMask m = LayerMask.GetMask("Gaming", "NotGaming");
        Debug.Log($"Layer mask: {m.value}");
        Debug.Log($"Manual mask: {(1 << gaming.layer) | (1 << notGaming.layer)}");

        if(((1 << gaming.layer) & m.value) != 0) {
            Debug.Log($"(1 << gaming.layer) & m.value) != 0 works");
        }

        if(((1 << notGaming.layer) & m.value) != 0) {
            Debug.Log($"(1 << notGaming.layer) & m.value) != 0 works");
        }

        if(((1 << notGaming.layer) & ~m.value) == 0) {
            return;
        }

        Debug.LogError("This shouldn't print");
    }
}
