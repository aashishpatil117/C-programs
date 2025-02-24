// See https://aka.ms/new-console-template for more information
using System;
using Grpc.Net.Client;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcClient{
    class Program{
        static async Task Main(string[] args){
            var channel=GrpcChannel.ForAddress("http://localhost:5106");
            var textclient=new TextAnalysis.TextAnalysisClient(channel);
            var result=await textclient.TextAnalyzeAsync(new TextRequest(){
                Name="!!!!"
            });
            Console.WriteLine($"word count={result.Wc}\nChar count={result.Cc}\nis palindrome={result.IsP}");
            //Console.WriteLine("snake");
        }
    }
}

