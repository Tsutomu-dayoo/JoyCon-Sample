using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Direct : MonoBehaviour
{
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;

    private void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
    }

    private void Update()
    {
        if (m_joycons == null || m_joycons.Count <= 0) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("Forward");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("Back");
        }
    }

    IEnumerator Forward()
    {
        for (int i = 0; i < 5; i++)
        {
            m_joyconL.SetRumble(0, -500.0f, 1.0f, 20);
            yield return new WaitForSeconds(0.02f);
            m_joyconL.SetRumble(0, 1.0f, 0.2f, 50);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Back()
    {
        for (int i = 0; i < 5; i++)
        {
            m_joyconL.SetRumble(0, 500.0f, 1.0f, 20);
            yield return new WaitForSeconds(0.02f);
            m_joyconL.SetRumble(0, -1.0f, 0.2f, 50);
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void OnGUI()
    {
        var style = GUI.skin.GetStyle("label");
        style.fontSize = 24;

        if (m_joycons == null || m_joycons.Count <= 0)
        {
            GUILayout.Label("Joy-Con が接続されていません");
            return;
        }

        if (!m_joycons.Any(c => c.isLeft))
        {
            GUILayout.Label("Joy-Con (L) が接続されていません");
            return;
        }
    }
}
