using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PullingJump : MonoBehaviour
{
    public GameObject StageText;
    public GameObject GameOverText;

    [SerializeField]
    private string TitleScene;
   

    private Rigidbody rb;
    private AudioSource gameOverAudioSource;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb =gameObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();  //ganeObject�͏ȗ�
        gameOverAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    private bool isCanJump;

    private void OnCollisionEnter(Collision collision)
    {
        //�Փ˂����u�ԂɌĂ΂�� 
       
    }

    private void OnCollisionStay(Collision collision)
    {
        // �Փ˂��Ă���ԁi�G��Ă���Ƃ��j�ɌĂ΂��
       

        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts=collision.contacts;
        
        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̏����擾
        Vector3 otherNormal = contacts[0].normal;

        // ������������x�N�g���B������1�B
        Vector3 upVector = new Vector3(0, 1, 0);

        // ������Ɩ@���̓��ρB��̃x�N�g���͂Ƃ��ɒ���1�Ȃ̂ŁA cos�Ƃ̌��ʂ� dotUN�ϐ��ɓ���
        float dotUN=Vector3.Dot(upVector, otherNormal);

        // ���ϒl�ɋt�O�p�`�֐� arccos ���|���Ċp�x���Z�o�B�����x���@�֕ϊ�����B����Ŋp�x���Z�o�ł����B
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        // ��̃x�N�g�����Ȃ��p��45�x��菬������΍ĂуW�����v�\�Ƃ���B
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        // ���ꂽ���ɌĂ΂��
       
        isCanJump=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(TitleScene);
        }

        Physics.gravity = new Vector3(0, -9.8f, 0);

        if(Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0) && isCanJump)
        {
            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;

            // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if(dist.sqrMagnitude==0)
            {
                return;
            }

            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;

        }

        if (rb.position.y <= -13)
        {
            isGameOver = true;
            StageText.SetActive(false);
            GameOverText.SetActive(true);
        }

        if(isGameOver == true)
        {
            gameOverAudioSource.Play();


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene ThisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(ThisScene.name);
            }
        }

       


    }
}
