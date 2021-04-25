using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject collectableSpawner;
    [SerializeField] private Animator earthAnim;
    [SerializeField] private GameObject upgradeUI;
    private GameObject currentSpawner;
    static private Vector3 spawnerPosition = new Vector3( 0, -6.73f,0 );
    // Start is called before the first frame update
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
