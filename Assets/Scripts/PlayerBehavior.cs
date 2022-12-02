using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private int swordDamage;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioSource sword;

    private Animator _animator;
    private List<GameObject> enemies;
    //[SerializeField] private float grenadeDamage;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(money <=0)
        {
            Die();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Attack();
            _animator.SetTrigger("Swing");
        }
    }

    public void ApplyDamage(int damage)
    {
        money -= damage;
        canvas.GetComponent<UIController>().SetMoneyText(money);
        GetComponent<AudioSource>().Play();
    }

    public void Die()
    {
        canvas.GetComponent<UIController>().EnableLosingText();
        GetComponent<CharacterController>().enabled = false;
        GetComponent<StarterAssets.FirstPersonController>().enabled = false;
    }
    public void Attack()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBehavior>().ApplyDamage(swordDamage);
        }
        sword.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        enemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        enemies.Remove(other.gameObject);
    }
}
