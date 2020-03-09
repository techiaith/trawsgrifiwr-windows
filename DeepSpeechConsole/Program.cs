using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using NAudio.Wave;

using DeepSpeechClient;
using DeepSpeechClient.Interfaces;
using DeepSpeechClient.Models;


namespace CSharpExamples
{
    class Program
    {

        const uint N_CEP = 26;
        const uint N_CONTEXT = 9;
        const uint BEAM_WIDTH = 500;
        const float LM_ALPHA = 0.75f;
        const float LM_BETA = 1.85f;

        private static WaveFileWriter waveFile = null;

        /// <summary>
        /// Get the value of an argurment.
        /// </summary>
        /// <param name="args">Argument list.</param>
        /// <param name="option">Key of the argument.</param>
        /// <returns>Value of the argument.</returns>
        static string GetArgument(IEnumerable<string> args, string option)
        => args.SkipWhile(i => i != option).Skip(1).Take(1).FirstOrDefault();

        static string MetadataToString(Metadata meta)
        {
            var nl = Environment.NewLine;
            string retval =
             Environment.NewLine + $"Recognized text: {string.Join("", meta?.Items?.Select(x => x.Character))} {nl}"
             + $"Prob: {meta?.Probability} {nl}"
             + $"Item count: {meta?.Items?.Length} {nl}"
             + string.Join(nl, meta?.Items?.Select(x => $"Timestep : {x.Timestep} TimeOffset: {x.StartTime} Char: {x.Character}"));
            return retval;
        }

        //
        static void Main(string[] args)
        {
            string model = null;
            string alphabet = null;
            string lm = null;
            string trie = null;
            string audio = null;
            bool extended = true;
            //if (args.Length > 0)
            //{
                model = GetArgument(args, "--model") ?? "models/arddweud/output_graph.pb";
                alphabet = GetArgument(args, "--alphabet") ?? "models/arddweud/alphabet.txt";
                lm = GetArgument(args, "--lm") ?? "models/arddweud/lm.binary";
                trie = GetArgument(args, "--trie") ?? "models/arddweud/trie";
                audio = GetArgument(args, "--audio");
                extended = !string.IsNullOrWhiteSpace(GetArgument(args, "--extended"));
            //}
             
            //
            IDeepSpeech sttClient = new DeepSpeech();

            //
            try
            {                    
                sttClient.CreateModel(model, N_CEP, N_CONTEXT, alphabet, BEAM_WIDTH);               
                sttClient.EnableDecoderWithLM(alphabet, lm, trie, LM_ALPHA, LM_BETA);

                if (!String.IsNullOrEmpty(audio))
                {
                    perform_stt(ref sttClient, audio, extended);
                }
                else
                {
                    WaveInEvent waveSource = new WaveInEvent();
                    waveSource.WaveFormat = new WaveFormat(16000, 1);
                    waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);

                    String tmpWavFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deepspeech.tmp.wav");

                    Console.Out.WriteLine("Adnabod lleferydd o'r microffon");
                    while (true)
                    {
                        Console.Out.WriteLine(Environment.NewLine);
                        Console.Out.WriteLine("Pwyswch 'Return' i ddechrau recordio...");                        
                        Console.In.ReadLine();

                        Console.Out.WriteLine("Yn recordio... pwyswch 'Return' i stopio'r recordio.");
                        waveFile = new WaveFileWriter(tmpWavFilePath, waveSource.WaveFormat);
                        waveSource.StartRecording();
                        Console.In.ReadLine();
                        waveSource.StopRecording();
                        waveFile.Dispose();

                        perform_stt(ref sttClient, tmpWavFilePath, extended);
                    }
                }                                           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                   
        }



        private static void perform_stt(ref IDeepSpeech sttClient, String audioFilePath, bool extended)
        {
            Stopwatch stopwatch = new Stopwatch();

            var waveBuffer = new WaveBuffer(File.ReadAllBytes(audioFilePath));
            using (var waveInfo = new WaveFileReader(audioFilePath))
            {
                Console.WriteLine("Running inference....");

                stopwatch.Start();

                string speechResult;
                if (extended)
                {
                    Metadata metaResult = sttClient.SpeechToTextWithMetadata(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);
                    speechResult = MetadataToString(metaResult);
                }
                else
                {
                    speechResult = sttClient.SpeechToText(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);
                }

                stopwatch.Stop();

                Console.WriteLine($"Audio duration: {waveInfo.TotalTime.ToString()}");
                Console.WriteLine($"Inference took: {stopwatch.Elapsed.ToString()}");
                Console.WriteLine((extended ? $"Extended result: " : "Recognized text: ") + speechResult);
                Console.WriteLine("\n\n");
            }
            waveBuffer.Clear();
        }
        
        private static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

    }
}