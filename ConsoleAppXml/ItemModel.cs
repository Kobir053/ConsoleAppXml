using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppXml
{
    public class ItemModel
    {
        public string Question {  get; set; }
        public string Answer { get; set; }


        public ItemModel() { 
            
        }

        public ItemModel(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
