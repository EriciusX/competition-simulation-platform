using UnityEngine;
using System.Collections;

public class DisplaySpin : MonoBehaviour
{
	public float speed = 1;
	public Vector3 axis = new Vector3(0, 1, 0);

	// Update is called once per frame
	void Update () {
		transform.Rotate(axis, speed*Time.deltaTime);
	}

    // private Vector3 GetCenter(GameObject target) {
	// 	Renderer[] mrs = target.gameObject.GetComponentsInChildren<Renderer>();
	// 	Vector3 center = target.transform.position;
	// 	if (mrs.Length != 0)
	// 	{
	// 		Bounds bounds = new Bounds(center, Vector3.zero);
	// 		foreach (Renderer mr in mrs) {
	// 			bounds.Encapsulate(mr.bounds);
	// 		}
	// 		center = bounds.center;
	// 	}
	// 	return center;
	// }
}
