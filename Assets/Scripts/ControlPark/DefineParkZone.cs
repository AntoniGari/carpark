using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineParkZone : MonoBehaviour {

	/// <summary>
	/// The color of the line.
	/// </summary>
	public Color lineColor;

	/// <summary>
	/// The nodes.
	/// </summary>
	private List<Transform> nodes = new List<Transform>();

	/// <summary>
	/// Raises the draw gizmos selected event.
	/// </summary>
	void OnDrawGizmos() {
		Gizmos.color = lineColor;

		Transform[] pathTransforms = GetComponentsInChildren<Transform>();
		nodes = new List<Transform>();

		for(int i = 0; i < pathTransforms.Length; i++) {
			if(pathTransforms[i] != transform) {
				nodes.Add(pathTransforms[i]);
			}
		}

		for(int i = 0; i < nodes.Count; i++) {
			Vector3 currentNode = nodes[i].position;
			Vector3 previousNode = Vector3.zero;

			if (i > 0) {
				previousNode = nodes[i - 1].position;
			} else if(i == 0 && nodes.Count > 1) {
				previousNode = nodes[nodes.Count - 1].position;
			}

			//Draw the Lines
			Gizmos.DrawLine(previousNode, currentNode);
			Gizmos.DrawWireSphere(currentNode, 0.3f);
		}
	}
}