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
        // �ڐG�����u�ԂɌĂ΂�� 

        isGet = true;
        getAudioSource.Play();
        animator.SetTrigger("Get");
    }

    private void OnTriggerStay(Collider other)
    {
        // �ڐG���Ă���ԁi�G��Ă���Ƃ��j�ɌĂ΂��
       

    }

    private void OnTriggerExit(Collider other)
    {
        // ���ꂽ���ɌĂ΂��
        
        
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
