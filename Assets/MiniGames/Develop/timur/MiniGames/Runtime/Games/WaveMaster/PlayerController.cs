using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectibleEffect;

    public Rigidbody rb;
    public float delta = 2.3f;
    public float lrSpeed = 2.5f;
    public float upSpeed = 2.5f;
    public float maxUpSpeed = 3f;
    public bool isBoosted = false;

    public AudioClip itemSound;
    public AudioClip deathSound;

    Vector3 startPos;
    bool isDead = false;

    GameController gameController;
    float hueValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Start()
    {
        hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();
    }

    void FixedUpdate()
    {
        if (isDead == true) return;



        transform.position = new Vector3(ReturnNewPosX(startPos.x, delta, Time.time, lrSpeed), transform.position.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            isBoosted = true;
            rb.AddForce(transform.up * upSpeed);
        }
        else if(!Input.GetMouseButton(0))
        {
            isBoosted = false;
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SoundManager.instance.PlaySingle(deathSound);
            Death();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            SoundManager.instance.PlaySingle(itemSound);
            GetItem(other);
        }
    }

    public float ReturnNewPosX(float x, float delta, float time, float lrSpeed)
    {
        return x + delta * Mathf.Sin(time * lrSpeed);
    }

    void GetItem(Collider other)
    {
        SetBackgroundColor();

        Destroy(Instantiate(collectibleEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject);
        gameController.AddScore();
    }

    void Death()
    {
        isDead = true;

        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 0.7f);
        StopPlayer();

        gameController.CallGameOver();
    }

    void StopPlayer()
    {
        Destroy(this.GetComponent<SphereCollider>());

        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
    }

    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);

        hueValue += 0.1f;
        if(hueValue >= 1)
        {
            hueValue = 0;
        }
    }
}
