using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

using NAudio.Wave;

using DeepSpeechClient.Interfaces;
using DeepSpeechClient.Models;


namespace DeepSpeechLib
{
    public class DeepSpeechTranscriber
    {
        
        const String DEFAULT_MODEL = "models/output_graph.pbmm";
        const String DEFAULT_KENLM_SCORER = "models/arddweud/kenlm.scorer";
        
        private String tmpWavFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deepspeech.tmp.wav");

        public String model { get; private set; }
        public String kenlm_scorer { get; private set; }

        private IDeepSpeech _sttClient;
        private WaveInEvent _waveSource;
        private static WaveFileWriter _waveFile;

        // lots lifted out of https://deepspeech.readthedocs.io/en/v0.7.3/DotNet-Examples.html

        //
        public DeepSpeechTranscriber(String model=DEFAULT_MODEL, 
                                     String kenlm_scorer= DEFAULT_KENLM_SCORER)
        {
            
            this.model = String.IsNullOrEmpty(model) ? DEFAULT_MODEL : model;
            this.kenlm_scorer = String.IsNullOrEmpty(kenlm_scorer) ? DEFAULT_KENLM_SCORER : kenlm_scorer;

            try
            {
                _sttClient = new DeepSpeechClient.DeepSpeech(this.model);
                _sttClient.EnableExternalScorer(this.kenlm_scorer);
            }
            catch (Exception exc)
            {
                Console.Out.WriteLine(exc.Message);
                Console.Out.WriteLine(exc.StackTrace);

                Tuple<string, bool> avx = isAvxSupported();
                if (avx.Item2 == false)
                {
                    throw new Exception(
                        "Methwyd creu'r peiriant DeepSpeech oherwydd ddiffyg yn CPU (" 
                        + avx.Item1 + ") y cyfrifiadur.\n\n"
                        + "Mae angen cyfrifiadur sydd a fath diweddar o CPU (fel Intel Core i3/5/7/9) ac sy'n cynorthwyo AVX.");                    
                } else
                {
                    throw new Exception("Methwyd creu'r peiriant DeepSpeech am rheswm anhysbys.");
                }
                
            }
            
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


        public List<String> Transcribe()
        {
            List<String> result = new List<string>();

            var waveBuffer = new WaveBuffer(File.ReadAllBytes(tmpWavFilePath));
            using (var waveInfo = new WaveFileReader(tmpWavFilePath))
            {
                Metadata metaResult = _sttClient.SpeechToTextWithMetadata(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);

                List<CandidateTranscript> candidateTranscriptions = metaResult.Transcripts.ToList();
                candidateTranscriptions.OrderByDescending(x => x.Confidence);                
                foreach (CandidateTranscript ct in candidateTranscriptions)
                {
                    result.Add(MetadataToString(ct));
                }
            }
            waveBuffer.Clear();
            return result;
        }

        private static string MetadataToString(CandidateTranscript transcript)
        {
            var nl = Environment.NewLine;
            string retval =
             Environment.NewLine + $"Recognized text: {string.Join("", transcript?.Tokens?.Select(x => x.Text))} {nl}"
             + $"Confidence: {transcript?.Confidence} {nl}"
             + $"Item count: {transcript?.Tokens?.Length} {nl}"
             + string.Join(nl, transcript?.Tokens?.Select(x => $"Timestep : {x.Timestep} TimeOffset: {x.StartTime} Char: {x.Text}"));
            return retval;
        }

        private static void onWaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveFile != null)
            {
                _waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                _waveFile.Flush();
            }

        }
        
        private static Tuple<string, bool> isAvxSupported()
        {
            ManagementObjectSearcher mso = new ManagementObjectSearcher("select * from Win32_Processor");
            String cpu_name = String.Empty;

            foreach (ManagementObject mo in mso.Get())
            {
                cpu_name = mo["Name"].ToString();
                break;              
            }
            
            bool hasAvx = false;

            if (cpu_name.Contains("Celeron"))
                hasAvx=false;
            else if ((cpu_name.Contains("Core(TM)") 
                && 
                (       cpu_name.Contains("i3") || 
                        cpu_name.Contains("i5") || 
                        cpu_name.Contains("i7") ||
                        cpu_name.Contains("i9"))
                )
            )
            {
                hasAvx = true;
            }
            else
            {
                hasAvx = false;
            }

            return new Tuple<string, bool>(cpu_name, hasAvx);
            
        }
    }
}
