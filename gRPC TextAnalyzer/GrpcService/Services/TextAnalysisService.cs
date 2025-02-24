using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Components.Forms;

namespace GrpcService.Services
{
    public class TextAnalysisService:TextAnalysis.TextAnalysisBase
    {
        public override Task<word_count> TextAnalyze(TextRequest txt, ServerCallContext context){
            
            if(txt.Name==" "){
                throw new ArgumentException();
            }
            int wordcount=count_words(txt.Name);
            string nowspaces=charCountNoWhiteSpaces(txt.Name);
            System.Text.RegularExpressions.Regex TitleRegex = new System.Text.RegularExpressions.Regex(
                "[^a-z0-9 ]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string ps = TitleRegex.Replace(nowspaces, String.Empty);
            int charcount=ps.Length;
            bool pal = CheckPalindrome(ps);
            var result=new word_count{
                Wc=wordcount,
                Cc=charcount,
                IsP=pal
            };
            //result=wordcount;
            return Task.FromResult(result);
        }
        private int count_words(string name){
             return name.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        private string charCountNoWhiteSpaces(string txt){
            return new string(txt.ToCharArray().Where(c=>!Char.IsWhiteSpace(c)).ToArray());
        }
        private bool CheckPalindrome(string name){
            //string s = name;
            //name=name.ToLower();
            char[] carr=name.ToCharArray();
            string rev=String.Empty;
            for(int i=carr.Length-1;i>-1;i--){
                rev+=carr[i];
            }
            if(rev==name){
                return true;
            }
            return false;
        }
       
    }
}
