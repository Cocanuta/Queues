using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Destroy (col.gameObject);
	}
}
