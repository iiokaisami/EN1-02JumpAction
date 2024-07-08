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
        // ÚG‚µ‚½uŠÔ‚ÉŒÄ‚Î‚ê‚é 

        isGet = true;
        getAudioSource.Play();
        animator.SetTrigger("Get");
    }

    private void OnTriggerStay(Collider other)
    {
        // ÚG‚µ‚Ä‚¢‚éŠÔiG‚ê‚Ä‚¢‚é‚Æ‚«j‚ÉŒÄ‚Î‚ê‚é
       

    }

    private void OnTriggerExit(Collider other)
    {
        // —£‚ê‚½‚ÉŒÄ‚Î‚ê‚é
        
        
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
