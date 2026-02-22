using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] zombies;

    public GameObject[] collectables;
    AudioManager audioManager;

    public GameObject selectedZombie;
    public static Gamemanager Instance;

    public Vector3 selectedSize;
    public Vector3 pushForce;


    private int score = 0;
    public TMP_Text collectibleText;
    public TMP_Text timerText;
    private float timer;
    public GameObject gameOverPanel;

    public float fallLimit = -5;
    private InputAction next, prev, jump;
    private int selectedIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
        Instance = this;
    }
    void Start()
    {
        Time.timeScale = 1;
        next = InputSystem.actions.FindAction("Next Zombie");
        prev = InputSystem.actions.FindAction("Prev Zombie");
        jump = InputSystem.actions.FindAction("Jump");

        

        SelectZomnie(selectedIndex);
    }
    
    void SelectZomnie(int index)
    {
        if (selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie);
    }
    // Update is called once per frame
    void Update()
    {
        if(next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectZomnie(selectedIndex);
            audioManager.PlaySFX(audioManager.selectedZombie);
        }
        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length -1;
            SelectZomnie(selectedIndex);
            audioManager.PlaySFX(audioManager.selectedZombie);
        }

        if(jump.WasPressedThisFrame())
        {
            Debug.Log("Jump");

            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddForce(pushForce);

            audioManager.PlaySFX(audioManager.jump);
        }

        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1") + "s";

        foreach (GameObject zombie in zombies)
        {
            if (zombie != null && zombie.transform.position.y < -5f)
            {
                GameOver();
               
            }
        }
    }

    
    public void CollectItem(int amount)
    {
        score += amount;
        UpdateUI();

      
    }
    
    public void UpdateUI()
    {
        if(collectibleText != null)
            collectibleText.text = "Score: " + score;
    }

    public void GameOver()
    {
        audioManager.PlaySFX(audioManager.gameOver);

        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
