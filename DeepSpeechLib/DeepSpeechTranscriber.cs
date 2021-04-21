using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

using NAudio.Wave;

using DeepSpeechClient.Interfaces;
using DeepSpeechClient.Models;

using System.Net.Http;
using Newtonsoft.Json;


namespace DeepSpeechLib
{
    public class DeepSpeechTranscriber
    {

        const String DEFAULT_MODEL = "models/am/techiaith_bangor_21.03.pbmm";
        const String DEFAULT_KENLM_SCORER = "models/lm/techiaith_bangor_21.03.scorer";

        private String tmpWavFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deepspeech.tmp.wav");
        private static String transcribeOnlineURL = "https://api.techiaith.org/deepspeech/transcribe/speech_to_text/";

        private Boolean useOnlineDeepSpeech = false;

        public String model { get; private set; }
        public String kenlm_scorer { get; private set; }

        private IDeepSpeech _sttClient;
        private WaveInEvent _waveSource;
        private static WaveFileWriter _waveFile;

        public bool isUsingOnlineDeepSpeech()
        {
            return useOnlineDeepSpeech;
        }


        // lots lifted out of https://deepspeech.readthedocs.io/en/v0.7.3/DotNet-Examples.html

        //
        public DeepSpeechTranscriber(String model = DEFAULT_MODEL,
                                     String kenlm_scorer = DEFAULT_KENLM_SCORER)
        {
            this.model = String.IsNullOrEmpty(model) ? DEFAULT_MODEL : model;
            this.kenlm_scorer = String.IsNullOrEmpty(kenlm_scorer) ? DEFAULT_KENLM_SCORER : kenlm_scorer;
            
            _waveSource = new WaveInEvent();
            _waveSource.WaveFormat = new WaveFormat(16000, 1);
            _waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(onWaveSource_DataAvailable);

        }

        public String CreateSpeechRecognitionEngine()
        {
            String message = String.Empty;

            Tuple<string, bool> avx = isAvxSupported();
            if (avx.Item2 == false)
            {
                message =
                    "Methwyd creu'r peiriant DeepSpeech oherwydd ddiffyg yn CPU ("
                    + avx.Item1 + ") y cyfrifiadur.\n\n"
                    + "Mae angen cyfrifiadur sydd a fath diweddar o CPU (fel Intel Core i3/5/7/9) ac sy'n cynorthwyo AVX.\n\n"
                    + "Defnyddiwch raglen fel CoreInfo64 i ddysgu mwy am eich CPU.\n\n"
                    + "RHYBUDD: Am defnyddio peiriant DeepSpeech ar-lein fel ddarpariaeth amgen.";

                useOnlineDeepSpeech = true;

                Console.Out.WriteLine(message);
                Console.Out.WriteLine();
            }
            else
            {
                try
                {
                    _sttClient = new DeepSpeechClient.DeepSpeech(this.model);
                    _sttClient.EnableExternalScorer(this.kenlm_scorer);
                }
                catch (Exception exc)
                {
                    message = "Methwyd creu'r peiriant DeepSpeech am rheswm anhysbys.\n\n" + exc.Message;
                    message += "RHYBUDD: Am defnyddio peiriant DeepSpeech ar-lein fel ddarpariaeth amgen.";

                    useOnlineDeepSpeech = true;

                    Console.Out.WriteLine(message);
                    Console.Out.WriteLine();

                }
            }

            return message;

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
            if (useOnlineDeepSpeech)
                return Transcribe_Online();
            else
                return Transcribe_Offline();
        }

        private List<String> Transcribe_Offline()
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

        private List<string> Transcribe_Online()
        {
            List<String> result = new List<string>();

            using (var httpClient = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();

                byte[] fileBytes = File.ReadAllBytes(tmpWavFilePath);
                form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), "soundfile", "speech.wav");

                using (HttpResponseMessage response = httpClient.PostAsync(transcribeOnlineURL, form).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                        dynamic jsonObj = JsonConvert.DeserializeObject(json);
                        result.Add(jsonObj.text.ToString());
                    }
                }
            }




            //using (var client = new HttpClient())
            //{
            //    using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture)))
            //    {
            //        content.Add(new StreamContent(new FileStream(tmpWavFilePath, FileMode.Open)), "soundfile");
            //        using (var message = await client.PostAsync(transcribeOnlineURL, content))
            //        {
            //            var input = await message.Content.ReadAsStringAsync();
            //            result.Add(input.ToString());
            //        }
            //    }
            //}
            
            //using (var httpClient = new HttpClient())
            //{
            //    using (var request = new HttpRequestMessage(new HttpMethod("POST"), transcribeOnlineURL))
            //    {
            //        MultipartFormDataContent multipartContent = new MultipartFormDataContent();
            //        multipartContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
            //        multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(tmpWavFilePath)), "soundfile", Path.GetFileName("speech.wav"));
            //        request.Content = multipartContent;

            //        HttpResponseMessage response = httpClient.SendAsync(request).Result;
            //        if (response.IsSuccessStatusCode)
            //        {
            //            String json = response.Content.ReadAsStringAsync().Result;
            //            result.Add(json);
            //        }
            //    }
            //}
            return result;
        }


        private static string MetadataToString(CandidateTranscript transcript)
        {
            var nl = Environment.NewLine;
            string retval =
             $"Recognized text: {string.Join("", transcript?.Tokens?.Select(x => x.Text))} {nl}"
             + $"Confidence: {transcript?.Confidence} {nl}"
             + $"Item count: {transcript?.Tokens?.Length} {nl}"
             + string.Join(nl, transcript?.Tokens?.Select(x => $"Timestep : {x.Timestep} TimeOffset: {x.StartTime} Char: {x.Text}"))
             + Environment.NewLine;

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
                hasAvx = HasAvxSupport();
            }

            return new Tuple<string, bool>(cpu_name, hasAvx);
            
        }


        private static bool HasAvxSupport()
        {
            try
            {
                long avxStatus = GetEnabledXStateFeatures();
                return (avxStatus & 4) != 0;
            }
            catch
            {
                return false;
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern long GetEnabledXStateFeatures();
    }

}
