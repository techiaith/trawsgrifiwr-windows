using DeepSpeechClient;
using DeepSpeechClient.Interfaces;
using DeepSpeechClient.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

        static void Main(string[] args)
        {
            string model = null;
            string alphabet = null;
            string lm = null;
            string trie = null;
            string audio = null;
            bool extended = false;
            if (args.Length > 0)
            {
                model = GetArgument(args, "--model");
                alphabet = GetArgument(args, "--alphabet");
                lm = GetArgument(args, "--lm");
                trie = GetArgument(args, "--trie");
                audio = GetArgument(args, "--audio");
                extended = !string.IsNullOrWhiteSpace(GetArgument(args, "--extended"));
            }

            // C: \Users\cbsc04\Documents\Visual Studio 2017\Projects\macsen

            const uint N_CEP = 26;
            const uint N_CONTEXT = 9;
            const uint BEAM_WIDTH = 500;
            const float LM_ALPHA = 0.75f;
            const float LM_BETA = 1.85f;

            Stopwatch stopwatch = new Stopwatch();

            using (IDeepSpeech sttClient = new DeepSpeech())
            {
                try
                {
                    Console.WriteLine("Loading model...");
                    stopwatch.Start();
                    sttClient.CreateModel(
                        model ?? "models/arddweud/output_graph.pb",
                        N_CEP, N_CONTEXT,
                        alphabet ?? "models/arddweud/alphabet.txt",
                        BEAM_WIDTH);
                    stopwatch.Stop();

                    Console.WriteLine($"\n\nModel loaded - {stopwatch.Elapsed.Milliseconds} ms");

                    Console.WriteLine("Loading LM...");
                    sttClient.EnableDecoderWithLM(
                        alphabet ?? "models/arddweud/alphabet.txt",
                        lm ?? "models/arddweud/lm.binary",
                        trie ?? "models/arddweud/trie",
                        LM_ALPHA, LM_BETA);
                                    
                    string audioFile = audio ?? "speech.wav";
                    var waveBuffer = new WaveBuffer(File.ReadAllBytes(audioFile));
                    using (var waveInfo = new WaveFileReader(audioFile))
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
                        Console.In.ReadLine();
                    }
                    waveBuffer.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}