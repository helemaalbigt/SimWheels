using UnityEngine;
using System.Collections;

public class LoadLevelOnTriggered : MonoBehaviour {

    public LoadScene _sceneLoad;

    void OnTriggerEnter(Collider col) {

        if (col.tag == "Player")
            LoadScene.ReloadScene(5f);
}
}
