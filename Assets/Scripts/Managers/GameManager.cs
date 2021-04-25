using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject collectableSpawner;
    [SerializeField] private Animator earthAnim;
    [SerializeField] private GameObject upgradeUI;
    private GameObject currentSpawner;
    private ArmourManager armourManager;
    static private Vector3 spawnerPosition = new Vector3( 0, -6.73f,0 );

    void Awake()
    {
        armourManager = GetComponent<ArmourManager>();
    }

    void Start()
    {
        StartPhase();
    }

    public void EndPhase ()
    {
        Destroy(currentSpawner);
        upgradeUI.SetActive(true);
        earthAnim.SetBool("isGameRunning", false);
    }

    public void StartPhase()
    {
        currentSpawner = Instantiate(collectableSpawner, spawnerPosition ,Quaternion.identity);
        upgradeUI.SetActive(false);
        earthAnim.SetBool("isGameRunning", true);
        armourManager.ResetArmour();
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
