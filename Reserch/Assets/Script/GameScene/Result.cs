using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;
using System.Text;

public class Result : MonoBehaviour
{
    private StreamWriter sw;

    // Start is called before the first frame update
    void Start()
    {
        sw = new StreamWriter(@"SaveData.csv", true, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "É^Å[Éì", "1", "2", "3" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickImportCSV()
    {
        string[] s1 = { "1", "Ç†", "Ç¢", "Ç§" };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);

        sw.Close();
    }

    public void onClickToTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
