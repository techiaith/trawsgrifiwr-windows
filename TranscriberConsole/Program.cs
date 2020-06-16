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
            string scorer = null;
            string audio = null;
            bool extended = true;

            model = GetArgument(args, "--model");
            scorer = GetArgument(args, "--scorer");
            audio = GetArgument(args, "--audio");
            extended = !string.IsNullOrWhiteSpace(GetArgument(args, "--extended"));

            DeepSpeechTranscriber _transcriber;

            try
            {
                _transcriber = new DeepSpeechTranscriber(model: model,
                                                         kenlm_scorer: scorer);
            }
            catch (Exception exc)
            {
                Console.Out.WriteLine(exc.Message);
                Console.Out.WriteLine("Pwyswch 'Return' i gau'r rhaglen.");
                Console.In.ReadLine();
                return;
            }
            

            List<string> sttResult;

            if (!String.IsNullOrEmpty(audio))
            {
                _transcriber.AddRecording(audio);
                sttResult = _transcriber.Transcribe();
                foreach (String r in sttResult)
                    Console.Out.WriteLine(r);
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
                    foreach (String r in sttResult)
                        Console.Out.WriteLine(r);
                }    
                
            }
                          
        }
               
    }

}