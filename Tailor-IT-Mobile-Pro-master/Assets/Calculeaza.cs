using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculeaza : MonoBehaviour
{
    public InputField inputField;
    public double constanta;
    public double lungime_picior;
    public double latime_sold;
    public double latime_umeri;
    public double latime_maini;
    public static double inaltime;
    public double input;
    public void Memoreaza()
    {
        input = double.Parse(inputField.text);
        constanta = input / 1.2;
        inaltime = input;
        latime_maini = constanta * 1.2;
        latime_umeri = constanta * 0.3;
        latime_sold = constanta * 0.2;
        lungime_picior = constanta * 0.6;
        double inaltimeBD;
        for (int i = 0; i < 15; i++)
        {

            inaltimeBD = double.Parse(GetDataValue(haina[i], "Inaltime:"));
            if (inaltimeBD >= inaltime - 3 && inaltimeBD < inaltime + 3)
            {
                print(GetDataValue(haina[i], "Nume:"));
            }
        }
    }
    
    public string[] haina;
    

    IEnumerator Start()
    {
        //Memoreaza();
#pragma warning disable CS0618 // Type or member is obsolete
        WWW hainaAleasa = new WWW("https://geophagous-series.000webhostapp.com/hainaAleasa.php");
#pragma warning restore CS0618 // Type or member is obsolete
        yield return hainaAleasa;
        string hainaAleasaString = hainaAleasa.text;
        
        haina = hainaAleasaString.Split(';');
        
    }
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
   
}
