using UnityEngine;
 
public class ThrowGrenadeScript : MonoBehaviour
{
    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;
    public static readonly int MaxGranadeCount = 5;
    public int granadeCount { get; set; } = MaxGranadeCount;

    private void Start()
    {
        rb_grenade = GetComponent<Rigidbody>();
    }
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスの左クリックをしたとき
        {
            if (granadeCount < 1) return;

            rb_grenade = Instantiate(grenade, transform.position, transform.rotation).GetComponent<Rigidbody>(); // グレネードを生成
            rb_grenade.AddForce(Vector3.Lerp(transform.forward * 1.5f,transform.up, 0.5f) * thrust, ForceMode.Impulse); // グレネードに力を一度加える
            granadeCount -= 1;
        }
    }

    public void IncreaseGranadeCount()
    {
        if (granadeCount < 5)
        {
            granadeCount++;
        }
    }
}