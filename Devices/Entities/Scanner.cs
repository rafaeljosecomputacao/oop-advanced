namespace Devices.Entities
{
    internal class Scanner : Device, IScanner
    {
        public string Scan()
        {
            return "Scanner scan result";
        }

        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Scanner processing: " + document);
        }      
    }
}