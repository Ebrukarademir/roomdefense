using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    public static PlayerHareketController instance;

    [Header("Hareket Ayarlari")]
    [SerializeField] private float normalHareketHizi = 10f;
    [SerializeField] private float kosmaHarekerHizi = 20f;

    private float hareketHizi;

    private Vector2 hareketVectoru;

    Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private Transform handTransform;

    private void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        hareketHizi = normalHareketHizi;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hareketHizi = kosmaHarekerHizi;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            hareketHizi = normalHareketHizi;
        }

        HareketFNC();
        SilahiDondurFNC();

    }


    void HareketFNC()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        print(h);

        hareketVectoru = new Vector2(x: h, y: v);
        hareketVectoru.Normalize();

        // float vectorUzunlugu = hareketVectoru.magnitude * hareketHizi;

        rb.velocity = hareketVectoru * hareketHizi;

        if (rb.velocity != Vector2.zero)
        {
            anim.SetBool("hareketEtsinmi", true);
        }
        else
        {
            anim.SetBool("hareketEtsinmi", false);
        }
    }


    void SilahiDondurFNC()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 hareketYonu = new Vector2(x: mousePos.x - playerPoint.x, y: mousePos.y - playerPoint.y);

        float angle = Mathf.Atan2(hareketYonu.y, hareketYonu.x) * Mathf.Rad2Deg;
        handTransform.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePos.x < playerPoint.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            handTransform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
            handTransform.localScale = Vector3.one;
        }
    }




}



