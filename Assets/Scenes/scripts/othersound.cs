using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class othersound : MonoBehaviour
{
    [SerializeField] private Text TextVol;
    public float sensitivity = 100;
    public float loudness = 0;
    public float pitch = 0;
    public int i=0;
    public static int getnum=-1;
    public static List<int> decibel = new List<int>();
    AudioSource _audio;
    public float listcount;
    public int listcountint;
    public float sum1,sum2,sum3;
    public float avg, avg1,avg2,avg3;

    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;
    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    public bool startMicOnStartup = true;

    public bool stopMicrophoneListener = false;
    public bool startMicrophoneListener = false;
    private bool microphoneListenerOn = false;
    public bool disableOutputSound = false;


    AudioSource src;

    public AudioMixer masterMixer;

    float timeSinceRestart = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (startMicOnStartup)
        {
            RestartMicrophoneListener();
            StartMicrophoneListener();

            _audio = GetComponent<AudioSource>();
            _audio.clip = Microphone.Start(null, true, 10, 44100);
            _audio.loop = true;
            _audio.mute = false;
            while (!(Microphone.GetPosition(null) > 0)) { }
            _audio.Play();
            _samples = new float[QSamples];
            _spectrum = new float[QSamples];
            _fSample = AudioSettings.outputSampleRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopMicrophoneListener)
        {
            StopMicrophoneListener();
        }
        if (startMicrophoneListener)
        {
            StartMicrophoneListener();
        }
        stopMicrophoneListener = false;
        startMicrophoneListener = false;

        MicrophoneIntoAudioSource(microphoneListenerOn);

        DisableSound(!disableOutputSound);

        loudness = GetAveragedVolume() * sensitivity * 100;

        if (loudness > 10)
        {
            getnum += 1;
            decibel.Add((int)loudness);
        }
        
        if (loudness < 20 && loudness > 5) { TextVol.text = "목소리가 너무 작아요! 조금 더 크고 당당하게!";}
        else if (loudness > 80) { TextVol.text = "목소리가 너무 커요! 조금만 작게 말해볼까요?"; }
        else { TextVol.text =  " "; }
    }
    public void SaveTime()
    {
        listcount = decibel.Count / 3;
        listcountint = (int)listcount;
        for (int i = 0; i < listcountint; i++){sum1 += decibel[i];}
        avg1 = sum1 / listcountint;
        for (int i = listcountint; i < 2*listcountint; i++){sum2 += decibel[i];}
        avg2 = sum2 / listcountint;
        for (int i = listcountint*2; i < decibel.Count; i++){sum3 += decibel[i];}
        avg3 = sum3 / listcountint;
        avg = (sum1 + sum2 + sum3) / decibel.Count;
        PlayerPrefs.SetFloat("avg", avg);
        PlayerPrefs.SetFloat("avg1", avg1);
        PlayerPrefs.SetFloat("avg2", avg2);
        PlayerPrefs.SetFloat("avg3", avg3);
        PlayerPrefs.SetInt("getnum", getnum);
        for (int j=0; j<decibel.Count; j++)
        {
            PlayerPrefs.SetInt("decibel" + j, decibel[j]);
        }
        PlayerPrefs.Save();
    }

    float GetAveragedVolume() {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData (data, 0);
        foreach (float s in data) {
            a +=Mathf.Abs(s);
        }
        return a/256;
    }
    void GetPitch() {
        GetComponent<AudioSource>().GetOutputData(_samples, 0);
        // fill array with samples 
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++) {
            sum += _samples[i] * _samples[i]; // sum squared samples 
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average 
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB 
        if (DbValue < -160) DbValue = -160; // clamp it to -160dB min 
                                            // get sound spectrum 
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++){
            // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;
            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max 
        }
        float freqN = maxN; // pass the index to a float variable 
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours 
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples; // convert index to frequency 
    } //stops everything and returns audioclip to null 
    public void StopMicrophoneListener(){
        //stop the microphone listener 
        microphoneListenerOn = false; //reenable the master sound in mixer 
        disableOutputSound = false; //remove mic from audiosource clip 
        src.Stop ();
        src.clip = null;
        Microphone.End (null);
    }
    public void StartMicrophoneListener(){ //start the microphone listener 
        microphoneListenerOn = true; //disable sound output (dont want to hear mic input on the output!) 
        disableOutputSound = true; //reset the audiosource 
        RestartMicrophoneListener ();
    } //controls whether the volume is on or off, use "off" for mic input (dont want to hear your own voice input!) 
      //and "on" for music input 

    public void DisableSound(bool SoundOn){
        float volume = 0;
        if (SoundOn) {
            volume = 0.0f;
        } else {
            volume = -80.0f;
        }
        masterMixer.SetFloat ("MasterVolume", volume);
    } // restart microphone removes the clip from the audiosource 
    public void RestartMicrophoneListener(){
        src = GetComponent<AudioSource>(); //remove any soundfile in the audiosource 
        src.clip = null;
        timeSinceRestart = Time.time;
    } //puts the mic into the audiosource 
    void MicrophoneIntoAudioSource (bool MicrophoneListenerOn){
        if (MicrophoneListenerOn){
            //pause a little before setting clip to avoid lag and bugginess 
            if (Time.time - timeSinceRestart > 0.5f && !Microphone.IsRecording (null)) {
                src.clip = Microphone.Start (null, true, 10, 44100);
                //wait until microphone position is found (?) 
                while (!(Microphone.GetPosition (null) > 0)) { }
                src.Play (); // Play the audio source 
            }
        }
    }
}