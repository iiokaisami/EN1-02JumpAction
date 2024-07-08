using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public GameObject StageText;
    public GameObject ClearText;

    [SerializeField]
    private string nextScene;
    private AudioSource clearAudioSource;

    private ItemScript item = new ItemScript();
    private bool isClear = false;

    // Start is called before the first frame update
    void Start()
    {
        clearAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ê⁄êGÇµÇΩèuä‘Ç…åƒÇŒÇÍÇÈ 

        isClear = true;
        clearAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isClear);   
        if (isClear == true)
        {
           
            StageText.SetActive(false);
            ClearText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
