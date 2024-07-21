namespace ConsoleAppXml
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("1. Create questions\r\n2. Answer Questions\r");
            int typed = Convert.ToInt32(Console.ReadLine());
            if(typed == 1)
            {
                Console.WriteLine("type your question: \r");
                string question = Console.ReadLine();
                Console.WriteLine("type your answer: \r");
                string answer = Console.ReadLine();
                XMLService xmlService = new XMLService("./XMLQuestionAndAnswers.xml");
                xmlService.CreateByModel(question, answer);

            }
            //else if(typed == 2)
            //{
            //    // showing list of questions
            //}
        }
    }
}
