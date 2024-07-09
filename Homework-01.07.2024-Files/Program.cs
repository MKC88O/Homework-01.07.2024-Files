namespace Homework_01._07._2024_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //string[] drives = Directory.GetLogicalDrives();

            var root = new DirectoryInfo(@"D:\World_of_Tanks_EU");

            Dictionary<string, int> extensionCount = [];
            Dictionary<string, double> extensionSize = [];

            var dirs = root.GetFiles("*", SearchOption.AllDirectories);

            foreach (var dir in dirs)
            {
                string extension = dir.Extension.ToLower();
                double fileSize = dir.Length;
                if (!string.IsNullOrEmpty(extension))
                {
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
            }

            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
            Console.WriteLine("|  № |   расширение   |   количество   |   объём в байтах   |   % от кол-ва   |   % от объёма    |");
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");

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
            foreach (var current in extensionCount)
            {
                double percentBytes = (double)extensionSize[current.Key] / totalBytes * 100;
                double percentCount = (double)current.Value / totalCount * 100;
                Console.Write("| {0, -3}", count + 1);
                Console.Write("| {0, -15}", current.Key);
                Console.Write("| {0, -15}", current.Value);
                Console.Write("| {0, -19}", extensionSize[current.Key]);
                Console.Write("| {0, -16}", Math.Round(percentCount, 2));
                Console.Write("| {0, -17}", Math.Round(percentBytes, 2));
                Console.WriteLine("| {0, -10}", "");
                count++;
                totalPercentCount += percentCount;
                totalPercentBytes += percentBytes;
            }
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
            Console.Write("| {0, -20}", "     ВСЕГО:      ");
            Console.Write("| {0, -15}", totalCount);
            Console.Write("| {0, -19}", totalBytes);
            Console.Write("| {0, -16}", totalPercentCount);
            Console.Write("| {0, -17}", totalPercentBytes);
            Console.WriteLine("| {0, -10}", "");
            Console.WriteLine("+----+----------------+----------------+--------------------+-----------------+------------------+");
        }
    }
}
