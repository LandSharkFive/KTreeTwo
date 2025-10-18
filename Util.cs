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
            long workingSet = currentProcess.PeakWorkingSet64 / (1024 * 1024);
            return Convert.ToInt32(workingSet);
        }

        public static bool IsSorted(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i-1] > list[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
