using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] string nextScene;
    public float power;
    public GameObject particleEffect;
    public float duration = 2.0f;
    public Transform spawnPosition;
    public AudioSource winMusic;
    Rigidbody rb;
    float inputX;
    float inputY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winMusic = GetComponent<AudioSource>();
        GameObject particleSystemInstance = Instantiate(particleEffect, spawnPosition.position, Quaternion.identity);

        ParticleSystem ps = particleSystemInstance.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        Destroy(particleSystemInstance, duration);

    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        rb.AddForce(inputX * power, 0, inputY * power);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            winMusic.Play();
            SceneManager.LoadScene(nextScene);
        }
    }


}