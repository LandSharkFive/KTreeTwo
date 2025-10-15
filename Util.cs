using System.Diagnostics;

namespace KTreeTwo
{
    public static class Util
    {
        private static Random random = new Random();

        public static void Shuffle(List<int> list)
        {
            for (int i = 0; i < list.Count; i++) 
            {
                int k = random.Next(list.Count);
                int value = list[k];
                list[k] = list[i];
                list[i] = value;
            }
        }

        public static int GetMemory()
        {
            Process currentProcess = Process.GetCurrentProcess();
            long workingSet = currentProcess.PeakWorkingSet64;
            double peakWorkingSet = workingSet / (1024.0 * 1024.0);
            return Convert.ToInt32(peakWorkingSet);
        }

    }
}
