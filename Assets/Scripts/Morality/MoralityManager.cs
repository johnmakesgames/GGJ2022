using UnityEngine;

public class MoralityManager : MonoBehaviour
{
    [SerializeField]
    private float m_Karma;

    public delegate void EventSignalled(object sender, float karmaValue);
    public event EventSignalled SignalKarmaChanged;

    // Start is called before the first frame update
    void Start()
    {
        m_Karma = 0;
    }

    private void Update()
    {
        Karma += Time.deltaTime;
    }

    public float Karma
    {
        get
        {
            return m_Karma;
        }
        set
        {
            m_Karma = value;
            SignalKarmaChanged.Invoke(this, m_Karma);
        }
    }

    public void IncrementKarma(float change)
    {
        Karma = Karma + change;
    }

    public static MoralityManager GetMoralityManager()
    {
        return GameObject.FindObjectOfType<MoralityManager>();
    }
}
