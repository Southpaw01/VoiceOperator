using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using Vosk;

namespace VoiceOperator.Speech
{
    public class SpeechToText
    {
        static string modelPath = "..\\..\\..\\model";
        static Model model = new Model(modelPath);

        VoskRecognizer recognizer = new VoskRecognizer(model, 48000.0f);

        WaveInEvent waveIn = new WaveInEvent();

        public void StartRecord()
        {

            model = new Model(modelPath);

            recognizer = new VoskRecognizer(model, 48000.0f);

            waveIn = new WaveInEvent();
            // Установка формата аудиоданных
            waveIn.WaveFormat = new WaveFormat(48000, 1);

                    // Обработчик события получения нового фрагмента аудио
                    waveIn.DataAvailable += (sender, e) =>
                    {
                        // Распознавание аудиоданных
                        recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded);
                    };

                    // Начало захвата аудио с микрофона
                    waveIn.StartRecording();
        }

        string StopRecord()
        {
            // Остановка захвата аудио с микрофона
            waveIn.StopRecording();

            try
            {
                string result = recognizer.Result().Substring(14);
                result = result.Substring(0, result.Length - 3);

                return result;
            }
            catch
            {
                return "Голос не распознан";
            }

        }



        public string GetAnswer()
        {
            return StopRecord();
        }
    }
}
