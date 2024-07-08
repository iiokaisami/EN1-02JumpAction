using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject TakenItemObject;
  
    private Animator animator;
    private AudioSource getAudioSource;
    private bool isGet = false;

    // Start is called before the first frame update
    void Start()
    {
        animator =GetComponent<Animator>();
        getAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 接触した瞬間に呼ばれる 

        isGet = true;
        getAudioSource.Play();
        animator.SetTrigger("Get");
    }

    private void OnTriggerStay(Collider other)
    {
        // 接触している間（触れているとき）に呼ばれる
       

    }

    private void OnTriggerExit(Collider other)
    {
        // 離れた時に呼ばれる
        
        
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
        TakenItemObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
