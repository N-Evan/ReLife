using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerInstance;

    public float playerHealth;
    [SerializeField] private float playerMaxHealth;
    public HealthbarBehavior playerHealthbar;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        StartFromHere();
        playerHealth = playerMaxHealth;
        playerHealthbar.SetHealth(playerHealth, playerMaxHealth);
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        playerHealthbar.SetHealth(playerHealth, playerMaxHealth);

        if (playerHealth < 0)
        {
            PlayerDeath();
        }
    }


    /*private void FixedUpdate()
    {
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.fixedDeltaTime;
    }

    private void OnLevelWasLoaded(int level)
    {
        StartFromHere();
    }*/

    private void StartFromHere()
    {
        if(SceneManager.GetActiveScene().name == "GameLevel1")
        {
            transform.position = GameObject.FindGameObjectWithTag("playerSpawn").transform.position;
        }
    }

    private void PlayerDeath()
    {
        FindObjectOfType<AudioManager>().Play("playerDeath");
        playerHealth = playerMaxHealth;
        StartFromHere();
    }

    public void DamageCounter(float dmg)
    {
        playerHealth -= dmg; 
    }
}