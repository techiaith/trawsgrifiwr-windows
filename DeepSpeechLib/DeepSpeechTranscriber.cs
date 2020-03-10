using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

using DeepSpeechClient;
using DeepSpeechClient.Interfaces;
using DeepSpeechClient.Models;


namespace DeepSpeechLib
{
    public class DeepSpeechTranscriber
    {
        const uint N_CEP = 26;
        const uint N_CONTEXT = 9;
        const uint BEAM_WIDTH = 500;
        const float LM_ALPHA = 0.75f;
        const float LM_BETA = 1.85f;

        const String DEFAULT_MODEL = "models/arddweud/output_graph.pb";
        const String DEFAULT_ALPHABET = "models/arddweud/alphabet.txt";
        const String DEFAULT_LANGUAGE_MODEL = "models/arddweud/lm.binary";
        const String DEFAULT_TRIE = "models/arddweud/trie";

        private String tmpWavFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deepspeech.tmp.wav");

        public String model { get; private set; }
        public String alphabet { get; private set; }
        public String language_model { get; private set; }
        public String trie { get; private set; }

        private IDeepSpeech _sttClient = new DeepSpeech();
        private WaveInEvent _waveSource;
        private static WaveFileWriter _waveFile;


        //
        public DeepSpeechTranscriber(String model=DEFAULT_MODEL, 
                                     String alphabet=DEFAULT_ALPHABET, 
                                     String language_model=DEFAULT_LANGUAGE_MODEL, 
                                     String trie=DEFAULT_TRIE)
        {
            this.model = String.IsNullOrEmpty(model) ? DEFAULT_MODEL : model;
            this.alphabet = String.IsNullOrEmpty(alphabet) ? DEFAULT_ALPHABET : alphabet;
            this.language_model = String.IsNullOrEmpty(language_model) ? DEFAULT_LANGUAGE_MODEL : language_model;
            this.trie = String.IsNullOrEmpty(trie) ? DEFAULT_TRIE : trie;
            
            _sttClient.CreateModel(this.model, N_CEP, N_CONTEXT, this.alphabet, BEAM_WIDTH);
            _sttClient.EnableDecoderWithLM(this.alphabet, this.language_model, this.trie, LM_ALPHA, LM_BETA);

            _waveSource = new WaveInEvent();
            _waveSource.WaveFormat = new WaveFormat(16000, 1);
            _waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(onWaveSource_DataAvailable);
        }

        public void StartRecording()
        {
            _waveFile = new WaveFileWriter(tmpWavFilePath, _waveSource.WaveFormat);
            _waveSource.StartRecording();
        }

        public void AddRecording(String audioFilePath)
        {
            File.Copy(audioFilePath, tmpWavFilePath);
        }

        public void StopRecording()
        {
            _waveSource.StopRecording();
            _waveFile.Dispose();
        }

        public Tuple<string, double?, int?, string> Transcribe()
        {            
            Tuple<string, double?, int?, string> result;

            var waveBuffer = new WaveBuffer(File.ReadAllBytes(tmpWavFilePath));
            using (var waveInfo = new WaveFileReader(tmpWavFilePath))
            {
                Metadata metaResult = _sttClient.SpeechToTextWithMetadata(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);
                result = new Tuple<string, double?, int?, string>(
                    Recaser.Recase(string.Join("", metaResult?.Items?.Select(x => x.Character))),
                    metaResult?.Probability,
                    metaResult?.Items.Length,
                    string.Join(Environment.NewLine, metaResult?.Items?.Select(x => $"Timestep : {x.Timestep} TimeOffset: {x.StartTime} Char: {x.Character}")));
            }
            waveBuffer.Clear();
            return result;
        }


        private static void onWaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveFile != null)
            {
                _waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                _waveFile.Flush();
            }
        }

    }
}
