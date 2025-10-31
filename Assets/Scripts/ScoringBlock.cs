using UnityEngine;

public class ScoringBlock : MonoBehaviour
{

    public GemeManager gemeManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gemeManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GemeManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            gemeManager.IncreaseScore();
        }

    }
}
