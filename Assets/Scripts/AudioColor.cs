using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AudioColor : AudioSyncer
{

    public Color[] beatColors;
    public Color restColor;

    private int m_randomIndex;
    private Renderer m_cube;

    // Start is called before the first frame update
    void Start()
    {
        m_cube = GetComponent<Renderer>();
    }

    private IEnumerator MoveToColor(Color _target)
    {
        Color _curr = m_cube.material.color;
        Color _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Color.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            m_cube.material.color = _curr;

            yield return null;
        }

        m_isBeat = false;
    }

    private Color RandomColor()
    {
        if (beatColors == null || beatColors.Length == 0)
        {
            return Color.white;
        }

        m_randomIndex = Random.Range(0, beatColors.Length);

        return beatColors[m_randomIndex];
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat)
        {
            return;
        }

        m_cube.material.color = Color.Lerp(m_cube.material.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        Color _c = RandomColor();

        StopCoroutine("MoveToColor");
        StartCoroutine("MoveToColor", _c);
    }
}
