using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    [SerializeField] private GameObject collectableSpawner;
    [SerializeField] private Animator earthAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject upgradeUI;
    private GameObject currentSpawner;
    private ArmourManager armourManager;
    private FuelManager fuelManager;
    static private Vector3 spawnerPosition = new Vector3( 0, -6.73f,0 );

    public int fuelChance = 70;

    void Awake()
    {
        armourManager = GetComponent<ArmourManager>();
        fuelManager = GetComponent<FuelManager>();
    }

    void Start()
    {
        fuelChance = 70;
        isGameRunning = false;
        StartPhase();
    }

    public void EndPhase ()
    {
        isGameRunning = false;
        Destroy(currentSpawner);
        upgradeUI.SetActive(true);
        earthAnim.SetBool("isGameRunning", false);
        SoundManager.StopAudioSource(audioSource);
    }

    public void StartPhase()
    {
        isGameRunning = true;
        currentSpawner = Instantiate(collectableSpawner, spawnerPosition ,Quaternion.identity);
        currentSpawner.GetComponent<CollectableSpawner>().fuelChance = fuelChance;
        upgradeUI.SetActive(false);
        earthAnim.SetBool("isGameRunning", true);
        SoundManager.PlayAudioSource(audioSource);
        armourManager.ResetArmour();
        fuelManager.ResetFuel();
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
