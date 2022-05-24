using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Text BossHealthText;

    private int _health;
    private int _startingHealth = 100;
    private int _enragedHealth = 50;


    private int _collisionHealthLoss = 10;

    private Animator _animator;
    private DialogueBoxManager _dialogueBoxManager;

    public Text gameWin;

    void Start()
    {
        _health = _startingHealth;
        BossHealthText.text = "Boss Health: " + _health;
        _animator = GetComponent<Animator>();
        _dialogueBoxManager = FindObjectOfType<DialogueBoxManager>();
        StartCoroutine(BeginScene());
    }

    private IEnumerator BeginScene()
    {
        // Wait for headset to load in

        _dialogueBoxManager.SetVisibility(true);
        yield return new WaitForSeconds(5);
        GetComponent<DialogueTrigger>().TriggerDialogue();

        // Wait for dialogue to finish and then start boss battle
        yield return new WaitForSeconds(5);
        _animator.SetBool("isEntry", true);
        _dialogueBoxManager.SetVisibility(false);
    }

    public void ReduceHealth()
    {
        _health -= _collisionHealthLoss;
        BossHealthText.text = "Boss Health: " + _health;

        if (_health == _enragedHealth)
            _animator.SetBool("isEnraged", true);

        if (_health == 0)
            _animator.SetBool("isDead", true);
    }

    public void Defeat()
    {
        StartCoroutine(shrinkObject(gameObject,1,0.1f));
    }

    IEnumerator shrinkObject(GameObject g, float scaleRate, float minScale)
    {
        _dialogueBoxManager.SetVisibility(true);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        _dialogueBoxManager.SetVisibility(false);
        float scale_y = g.transform.localScale.y;
        while (scale_y > minScale)    //    while the object is larger than desired
        {
            scale_y -= scaleRate * Time.deltaTime;    //    calculate the new scale relative to the rate
            Vector3 scale = g.transform.localScale;
            scale.y = scale_y;
            g.transform.localScale = scale;
            yield return null;    //    wait a frame
        }
        Destroy(gameObject);
        gameWin.gameObject.SetActive(true);
        yield break;
    }
}
