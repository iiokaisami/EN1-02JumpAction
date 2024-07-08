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
        // rb = GetComponent<Rigidbody>();  //ganeObjectは省略
        gameOverAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    private bool isCanJump;

    private void OnCollisionEnter(Collision collision)
    {
        //衝突した瞬間に呼ばれる 
       
    }

    private void OnCollisionStay(Collision collision)
    {
        // 衝突している間（触れているとき）に呼ばれる
       

        // 衝突している点の情報が複数格納されている
        ContactPoint[] contacts=collision.contacts;
        
        // 0番目の衝突情報から、衝突している点の情報を取得
        Vector3 otherNormal = contacts[0].normal;

        // 上方向を示すベクトル。長さは1。
        Vector3 upVector = new Vector3(0, 1, 0);

        // 上方向と法線の内積。二つのベクトルはともに長さ1なので、 cosθの結果が dotUN変数に入る
        float dotUN=Vector3.Dot(upVector, otherNormal);

        // 内積値に逆三角形関数 arccos を掛けて角度を算出。それを度数法へ変換する。これで角度が算出できた。
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        // 二つのベクトルがなす角が45度より小さければ再びジャンプ可能とする。
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        // 離れた時に呼ばれる
       
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
            // クリックした座標と離した座標の差分を取得
            Vector3 dist = clickPosition - Input.mousePosition;

            // クリックとリリースが同じ座標ならば無視
            if(dist.sqrMagnitude==0)
            {
                return;
            }

            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする
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
