using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	private Material[] materials;

	[SerializeField] private Color[] clothColors;
	[SerializeField] private Color[] hairColors;
	[SerializeField] private Color[] skinColors;

    void Start()
    {
		materials = GetComponentInChildren<Renderer>().materials;

		materials[0].SetColor("_Color", clothColors[Random.Range(0, clothColors.Length)]);
		materials[1].SetColor("_Color", skinColors[Random.Range(0, skinColors.Length)]);
		materials[4].SetColor("_Color", hairColors[Random.Range(0, hairColors.Length)]);
    }
}
