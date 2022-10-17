using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] AudioSource _audioItm;
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioClip _hitEnemy;
    [SerializeField] AudioClip _getSP;
    [SerializeField] AudioClip _getItem;

    [SerializeField] GameObject _kira;
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    [SerializeField] LayerMask _defalt;
    [SerializeField] LayerMask _muteki;

    Vector2 up = new Vector2(0, 2);
    Vector2 down = new Vector2(0, -2);
    Vector2 left = new Vector2(0, 0);
    Vector2 right = new Vector2(0, 2);

    GameManager _gm;
    bool a;
    void Start()
    {
        _audioItm = _audioItm.GetComponent<AudioSource>();
        _audio = GetComponent<AudioSource>();
        dest = transform.position;
        _gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {

        if (_gm._isGame)
        {
            if (!a)
            {
                dest = transform.position;
                a = true;
            }
            // Move closer to Destination
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);

            // Check for Input if not moving
            if ((Vector2)transform.position == dest)
            {
                if (Input.GetKey(KeyCode.W) && valid(Vector2.up))
                    dest = (Vector2)transform.position + Vector2.up;
                if (Input.GetKey(KeyCode.D) && valid(Vector2.right))
                    dest = (Vector2)transform.position + Vector2.right;
                if (Input.GetKey(KeyCode.S) && valid(-Vector2.up))
                    dest = (Vector2)transform.position - Vector2.up;
                if (Input.GetKey(KeyCode.A) && valid(-Vector2.right))
                    dest = (Vector2)transform.position - Vector2.right;
            }
        }
    }

    bool valid(Vector2 dir)
    {
        Debug.Log("v");
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        Debug.DrawLine(pos, pos + dir, Color.red);
        return (hit.collider.gameObject.tag != "Wall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Enemy")
        {
            _audio.PlayOneShot(_hitEnemy);
            StartCoroutine(muteki());
            FindObjectOfType<GameManager>().AddScore(1, -5);
        }

        if (collision.gameObject.tag == "Item")
        {
            _audioItm.PlayOneShot(_getItem);
        }
    }

    IEnumerator muteki()
    {
        gameObject.layer = 9;
        this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -10);
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 10);
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -10);
        yield return new WaitForSeconds(0.4f);
        this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 10);
        yield return new WaitForSeconds(0.7f);
        gameObject.layer = 10;
    }

    public IEnumerator mutekiItem()
    {
        _audio.PlayOneShot(_getSP);
        Debug.Log("SS");
        var a = Instantiate(_kira);
        a.transform.position = transform.position;
        a.transform.SetParent(transform);
        gameObject.layer = 9;
        yield return new WaitForSeconds(5f);
        Destroy(a);
        gameObject.layer = 10;
    }
}