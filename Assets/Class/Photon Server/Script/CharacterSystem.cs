using Photon.Pun;
using UnityEngine;

public class CharacterSystem : MonoBehaviourPun, IPunObservable
{
    [SerializeField] float angleSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 5.0f;

    [SerializeField] float mouseX;
    [SerializeField] float health = 100;
    [SerializeField] Camera temporaryCamera;

    void Awake()
    {    
        // OnPhotonSerializeView 초당 호출하는 수
        PhotonNetwork.SerializationRate = 10;
    }

    private void Start()
    {
        // 현재 플레이어가 나 자신이라면 
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            temporaryCamera.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;
        
        direction = new Vector3
        (
            Input.GetAxisRaw("Horizontal"), 0,  Input.GetAxisRaw("Vertical")
        );

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        mouseX += Input.GetAxis("Mouse X") * angleSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 오브젝트라면 쓰기 부분이 실행됩니다.
        if (stream.IsWriting)
        {
            // 네트워크를 통해 데이터를 보냅니다.
            stream.SendNext(health);
        }
        else // 원격 오브젝트라면 읽기 부분이 실행됩니다.
        {
            // 네트워크를 통해서 데이터 받습니다.
            health = (float)stream.ReceiveNext();
        }    
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.gameObject.CompareTag("Bee"))
        {
            PhotonView view = other.gameObject.GetComponent<PhotonView>();
            StartCoroutine(temporaryCamera.GetComponent<CameraShake>().Shake(0.5f, 0.25f));

            if (view.IsMine)
            {
               health -= 20;

               PhotonNetwork.Destroy(other.gameObject);
            }
        }
    }


}


