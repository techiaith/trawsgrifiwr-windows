using System;
using System.Linq;
using System.Collections.Generic;

using DeepSpeechLib;

namespace CSharpExamples
{
    class Program
    {
       
        /// <summary>
        /// Get the value of an argurment.
        /// </summary>
        /// <param name="args">Argument list.</param>
        /// <param name="option">Key of the argument.</param>
        /// <returns>Value of the argument.</returns>
        static string GetArgument(IEnumerable<string> args, string option) => args.SkipWhile(i => i != option).Skip(1).Take(1).FirstOrDefault();
        
        //
        static void Main(string[] args)
        {
            string model = null;
            string alphabet = null;
            string lm = null;
            string trie = null;
            string audio = null;
            bool extended = true;

            model = GetArgument(args, "--model");
            alphabet = GetArgument(args, "--alphabet");
            lm = GetArgument(args, "--lm");
            trie = GetArgument(args, "--trie");
            audio = GetArgument(args, "--audio");
            extended = !string.IsNullOrWhiteSpace(GetArgument(args, "--extended"));

            DeepSpeechTranscriber _transcriber;

            try
            {
                _transcriber = new DeepSpeechTranscriber(model: model,
                                                         alphabet: alphabet,
                                                         language_model: lm,
                                                         trie: trie);
            }
            catch (Exception exc)
            {
                Console.Out.Write("Pwyswch 'Return' i gau'r rhaglen.");
                Console.In.ReadLine();
                return;
            }
            

            Tuple<string, double?, int?, string> sttResult;

            if (!String.IsNullOrEmpty(audio))
            {
                _transcriber.AddRecording(audio);
                sttResult = _transcriber.Transcribe();
                Console.Out.WriteLine(sttResult.Item1);
            }
            else
            {
                Console.Out.WriteLine("Adnabod lleferydd o'r microffon");
                while (true)
                {
                    Console.Out.WriteLine(Environment.NewLine);
                    Console.Out.WriteLine("Pwyswch 'Return' i ddechrau recordio...");                        
                    Console.In.ReadLine();

                    Console.Out.WriteLine("Yn recordio... pwyswch 'Return' i stopio'r recordio.");

                    _transcriber.StartRecording();

                    Console.In.ReadLine();
                    _transcriber.StopRecording();

                    sttResult = _transcriber.Transcribe();
                    Console.Out.WriteLine(sttResult.Item1);
                
                }    
                
            }
                          
        }



        //private static void perform_stt(ref IDeepSpeech sttClient, String audioFilePath, bool extended)
        //{
        //    Stopwatch stopwatch = new Stopwatch();

        //    var waveBuffer = new WaveBuffer(File.ReadAllBytes(audioFilePath));
        //    using (var waveInfo = new WaveFileReader(audioFilePath))
        //    {
        //        Console.WriteLine("Running inference....");

        //        stopwatch.Start();

        //        string speechResult;
        //        if (extended)
        //        {
        //            Metadata metaResult = sttClient.SpeechToTextWithMetadata(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);
        //            speechResult = MetadataToString(metaResult);
        //        }
        //        else
        //        {
        //            speechResult = sttClient.SpeechToText(waveBuffer.ShortBuffer, Convert.ToUInt32(waveBuffer.MaxSize / 2), 16000);
        //        }

        //        stopwatch.Stop();

        //        Console.WriteLine($"Audio duration: {waveInfo.TotalTime.ToString()}");
        //        Console.WriteLine($"Inference took: {stopwatch.Elapsed.ToString()}");
        //        Console.WriteLine((extended ? $"Extended result: " : "Recognized text: ") + speechResult);
        //        Console.WriteLine("\n\n");
        //    }
        //    waveBuffer.Clear();
        //}
               
    }

}