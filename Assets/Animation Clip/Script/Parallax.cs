using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] Rect rect;
    [SerializeField] RawImage rawImage;

    [SerializeField] float speed = 0.25f;

    void Update()
    {
        rect = rawImage.uvRect;
        rect.x += Time.deltaTime * speed;
        rawImage.uvRect = rect;
    }
}

