using UnityEngine;
using System.Collections;

public class BakeAllProbes : MonoBehaviour {

	IEnumerator Start(){
		yield return new WaitForSeconds (2f);
		foreach (ReflectionProbe rp in FindObjectsOfType<ReflectionProbe>()) {
			if (rp.mode == UnityEngine.Rendering.ReflectionProbeMode.Realtime) {
				rp.RenderProbe ();
			}
		}
		Destroy (this.gameObject);
	}
}
