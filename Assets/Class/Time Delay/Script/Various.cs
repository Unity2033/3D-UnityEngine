using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Various : MonoBehaviour
{
    private float timer;
    public Image stateImage;
    public Sprite [] stateIcon;

    void Start()
    {
        InvokeRepeating("Position", 1, 3);

        StartCoroutine(Paint());
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 5.0f)
        {
            Invoke("ChangeSprite", 0);

            timer = 0.0f;
        }
    }

    IEnumerator Paint()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            gameObject.GetComponent<Renderer>().material.color = 
                new Color
                (
                    Random.Range(0, 2), 
                    Random.Range(0, 2), 
                    Random.Range(0, 2)
                );
        }
    }
    
    public void Position()
    {
        transform.position = new Vector3
            (
               Random.Range(-2.5f, 2.5f),
               0,
               Random.Range(-2.5f, 2.5f)
            );
    }

    public void ChangeSprite()
    {
        switch (Random.Range(0, 3))
        {
            case 0 : stateImage.sprite = stateIcon[0];
                break;
            case 1 : stateImage.sprite = stateIcon[1];
                break;
            case 2 : stateImage.sprite = stateIcon[2];
                break;
        }
    }
}
