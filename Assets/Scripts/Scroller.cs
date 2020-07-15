using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour 
{
	private Vector2 offset;

	void Update()
	{
		offset = new Vector2 (-transform.position.x / 600, -transform.position.z / 600);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
