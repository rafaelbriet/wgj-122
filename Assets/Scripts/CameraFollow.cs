using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	private Transform player;

    void LateUpdate()
    {
		transform.position = new Vector3(player.position.x, this.transform.position.y, transform.position.z);
    }
}
