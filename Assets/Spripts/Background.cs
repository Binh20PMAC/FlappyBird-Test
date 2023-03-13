using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private float MaterialSpeed;
    [SerializeField] private Image Image;

    private void Update()
    {
        Material material = Image.material;
        Vector2 offset = material.mainTextureOffset;
        offset.x += Time.deltaTime * MaterialSpeed;
        material.mainTextureOffset = offset;
    }
}
