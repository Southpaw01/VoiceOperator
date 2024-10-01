using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VoiceOperator.Speech
{
    public class TextToSpeech
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public void Speak(string text)
        {
            synth = new SpeechSynthesizer();

            synth.SetOutputToDefaultAudioDevice();

            synth.Speak(text);
        }
    }
}
