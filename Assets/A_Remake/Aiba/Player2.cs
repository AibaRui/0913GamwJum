using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] GameObject _kira;

    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    GameManager _gm;

    bool a;
    [SerializeField] LayerMask _defalt;
    [SerializeField] LayerMask _muteki;
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (_gm._isGame)
        {
            if(!a)
            {    
                dest = transform.position;
                a = true;
            }
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);

            // Check for Input if not moving
            if ((Vector2)transform.position == dest)
            {
                if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                    dest = (Vector2)transform.position + Vector2.up;
                if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                    dest = (Vector2)transform.position + Vector2.right;
                if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                    dest = (Vector2)transform.position - Vector2.up;
                if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                    dest = (Vector2)transform.position - Vector2.right;
            }
        }
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        Debug.DrawLine(pos, pos + dir, Color.red);
        return (hit.collider.gameObject.tag !="Wall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            StartCoroutine(muteki());
            FindObjectOfType<GameManager>().AddScore(2, -5);
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
        var a = Instantiate(_kira);
        a.transform.position = transform.position;
        a.transform.SetParent(transform);
        gameObject.layer = 9;
        yield return new WaitForSeconds(5f);
        Destroy(a);
        gameObject.layer = 10;
    }
}