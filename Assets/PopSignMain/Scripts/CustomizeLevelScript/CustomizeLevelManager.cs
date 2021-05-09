﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomizeLevelManager : MonoBehaviour
{
    static public CustomizeLevelManager Instance;
    public bool tryingToCustomize = false;
    public HashSet<string> selectedWord = new HashSet<string>();
    public Dictionary<int, LinkedList<TextAsset>> levels = new Dictionary<int, LinkedList<TextAsset>>();

    void readlevel() {
        UnityEngine.Object[] level = Resources.LoadAll("Levels");
        foreach (UnityEngine.Object temp in level) {
            TextAsset textAsset = (TextAsset)temp;
            //Debug.Log(textAsset.text);
            int index = textAsset.text.IndexOf("COLOR LIMIT");
            string numstr = textAsset.text.Substring(index + 12, 1);
            Debug.Log(numstr);
            int numlevel = Int32.Parse(numstr);
            if (levels.ContainsKey(numlevel)) {
                levels[numlevel].AddLast(textAsset);
            } else {
                LinkedList<TextAsset> newlist = new LinkedList<TextAsset>();
                newlist.AddLast(textAsset);
                levels.Add(numlevel, newlist);
            }
        }
        Debug.Log(levels.Keys);
        Debug.Log(levels.Values);
    }
        
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            // filter level files and population levels variable
            readlevel();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
