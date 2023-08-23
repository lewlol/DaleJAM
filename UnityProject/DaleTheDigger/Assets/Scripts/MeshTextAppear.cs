using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeshTextAppear : MonoBehaviour
{
    public GameObject TextMesh;
    public void GenerateText(Vector2 position, float time, string text, float size)
    { 
        GameObject textMesh = Instantiate(TextMesh, position, Quaternion.identity);
        TextMeshProUGUI tmp = textMesh.GetComponent<TextMeshProUGUI>();

        tmp.text = text;
        tmp.fontSize = size; //5 is normally a good size
        Destroy(textMesh, time);
    }
}
