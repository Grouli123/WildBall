using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject _death;   
    [SerializeField] private GameObject _win; 
    [SerializeField] private AudioSource _eat;
    [SerializeField] private AudioSource _lavaDeath;
    [SerializeField] private AudioSource _usualDeath;
    [SerializeField] private AudioSource _winSound;

     private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("WinEffect"))
      {
        EffectWin();
      }
      if (other.CompareTag("Win"))
      {
        LoadWinScene();         
      } 
      if (other.CompareTag("Death"))
      {
        LavaDeath();
      } 
      if (other.CompareTag("UsualDeath"))
      {
        UsualDeath();
      } 
      if (other.CompareTag("Lose"))
      {
        LoadLoseScene(); 
      }        
      if(other.CompareTag("SpeedBonus"))
      {
        SpeedBonus();
      }
    }

    private void EffectWin()
    {
      _win.SetActive(true);   
      _winSound.enabled = true;
      _winSound = GetComponent<AudioSource>();
      _winSound.Play();    
    }

    private void LoadWinScene()
    {
      SceneManager.LoadScene(2);   
    }

    private void LavaDeath()
    {
      _lavaDeath.enabled = true;
      _lavaDeath = GetComponent<AudioSource>();
      _lavaDeath.Play();
      _death.SetActive(true);
    }

    private void UsualDeath()
    {
      _usualDeath.enabled = true;
      _usualDeath = GetComponent<AudioSource>();
      _usualDeath.Play();
      _death.SetActive(true);
    }

    private void LoadLoseScene()
    {
      SceneManager.LoadScene(3); 
    }

    private void SpeedBonus()
    {
      _eat.enabled = true;
      _eat = GetComponent<AudioSource>();
      _eat.Play();
    }
}