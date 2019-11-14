﻿/* dataCollect.cs
 * 11.13.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script contains a class for balloon data. The collectValues()
 * function will create a new object and add it to an arraylist. This
 * arraylist can be called by getDataSet() to get the collection of
 * balloon data objects. The getCSVFormat() function uses the
 * data set to create a string in csv format.
 */

using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class dataCollect : MonoBehaviour
{
    public gm_uiValuesUpdate uiValues;
    public Wind windScript;
    // balloon collection
    private ArrayList balloonCollection = new ArrayList();
    // balloon object

    public void collectValues()
    {
        BalloonData balloonData = new BalloonData(uiValues.currentRadiusM,
            uiValues.surfaceArea, uiValues.volume, uiValues.liftForce, 0,
            windScript.constantStrength, windScript.WeightForce());
        balloonCollection.Add(balloonData);
    }
    public ArrayList getDataSet()
    {
        return balloonCollection;
    }

    public string getCSVFormat()
    {
        string csv = "Radius, Surface Area, Volume, Lift Force, Mass, Wind Speed, Weight Force\n";

        foreach(BalloonData obj in getDataSet())
        {
            csv += obj.CurrentRadiusM.ToString("0.00") + ",";
            csv += obj.SurfaceArea.ToString("0.00") + ",";
            csv += obj.Volume.ToString("0.00") + ",";
            csv += obj.LiftForce.ToString("0.00") + ",";
            csv += obj.Mass.ToString("0.00") + ",";
            csv += obj.WindSpeed.ToString("0.00") + ",";
            csv += obj.WeightForce.ToString("0.00") + "\n";
        }
        return csv;
    }
    //private void Update()
    //{
    //    collectValues();
    //    Debug.Log(getCSVFormat());
    //}

}

// class of balloon properties
public class BalloonData
{
    private float currentRadiusM;
    private float surfaceArea;
    private float volume;
    private float liftForce;
    private float mass;
    private float windSpeed;
    private float weightForce;

    public BalloonData(float currentRadiusM, float surfaceArea, float volume, float liftForce, float mass, float windSpeed, float weightForce)
    {
        this.currentRadiusM = currentRadiusM;
        this.surfaceArea = surfaceArea;
        this.volume = volume;
        this.liftForce = liftForce;
        this.mass = mass;
        this.windSpeed = windSpeed;
        this.weightForce = weightForce;
    }

    public float CurrentRadiusM { get => currentRadiusM; set => currentRadiusM = value; }
    public float SurfaceArea { get => surfaceArea; set => surfaceArea = value; }
    public float Volume { get => volume; set => volume = value; }
    public float LiftForce { get => liftForce; set => liftForce = value; }
    public float Mass { get => mass; set => mass = value; }
    public float WindSpeed { get => windSpeed; set => windSpeed = value; }
    public float WeightForce { get => weightForce; set => weightForce = value; }
}

