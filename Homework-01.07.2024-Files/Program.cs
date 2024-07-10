namespace Homework_01._07._2024_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] drives = Directory.GetLogicalDrives();

            //var root = new DirectoryInfo(@"D:\World_of_Tanks_EU");
            var root = new DirectoryInfo(drives[0] + "Program Files (x86)");
            SortedDictionary<string, int> extensionCount = [];
            SortedDictionary<string, double> extensionSize = []; 
            var dirs = root.GetFiles("*", SearchOption.AllDirectories);

            foreach (var dir in dirs)
            {
                string extension = dir.Extension.ToLower();
                double fileSize = dir.Length;
                if (extensionCount.ContainsKey(extension))
                {
                    extensionCount[extension]++;
                    extensionSize[extension] += fileSize;
                }
                else
                {
                    extensionCount.Add(extension, 1);
                    extensionSize.Add(extension, fileSize);
                }
            }

            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
            Console.WriteLine("|  № |   расширение   |   количество   |   объём в байтах   |   % от кол-ва   |   % от объёма    |");
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");

            var sortedDict = extensionCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int totalCount = 0;
            foreach (var total in extensionCount.Values)
            {
                totalCount += total;
            }

            double totalBytes = 0;
            foreach (var file in dirs)
            {
                totalBytes += file.Length;
            }
            int count = 0;
            double totalPercentCount = 0;
            double totalPercentBytes = 0;
            foreach (var current in sortedDict)
            {
                if (count >= 50)
                {
                    break;
                }

                double percentBytes = (double)extensionSize[current.Key] / totalBytes * 100;
                double percentCount = (double)current.Value / totalCount * 100;
                Console.Write("| {0, -3}", count + 1);
                Console.Write("| {0, -15}", current.Key);
                Console.Write("| {0, -15}", current.Value);
                Console.Write("| {0, -19}", extensionSize[current.Key]);
                Console.Write("| {0, -16}", Math.Round(percentCount, 2));
                Console.Write("| {0, -17}", Math.Round(percentBytes, 2));
                Console.WriteLine("|");
                count++;
                totalPercentCount += percentCount;
                totalPercentBytes += percentBytes;
            }
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
            Console.Write("| {0, -20}", "     ВСЕГО:      ");
            Console.Write("| {0, -15}", totalCount);
            Console.Write("| {0, -19}", totalBytes);
            Console.Write("| {0, -16}", Math.Round(totalPercentCount, 2));
            Console.Write("| {0, -17}", Math.Round(totalPercentBytes, 2));
            Console.WriteLine("|");
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
            
        }
    }
}
