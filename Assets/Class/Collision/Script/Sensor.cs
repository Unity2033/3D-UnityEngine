using UnityEngine;
using UnityEngine.Video;

public class Sensor : MonoBehaviour
{
    public Mesh [] mesh;
    private VideoPlayer video;
    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        video = GetComponent<VideoPlayer>();
    }

    // 물리적인 충돌을 하지 않고 충돌을 했을 때 동작하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        video.Play();
        video.isLooping = true;
    }

    // 물리적인 충돌을 하지 않고 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        meshFilter.mesh = mesh[0];
    }

    // 물리적인 충돌을 하지 않고 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        video.Stop();
        meshFilter.mesh = mesh[1];
    }

}
