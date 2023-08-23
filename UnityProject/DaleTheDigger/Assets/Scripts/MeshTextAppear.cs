using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeshTextAppear : MonoBehaviour
{
    GameObject TextMesh;
    public void GenerateText(Vector2 position, float time, string text, float size)
    { 
        GameObject textMesh = Instantiate(TextMesh, position, Quaternion.identity);
        TextMeshProUGUI tmp = textMesh.GetComponent<TextMeshProUGUI>();

        tmp.text = text;
        tmp.fontSize = size;
        Destroy(textMesh, time);
    }
}
