public class Program {
    public static void Main(string[] args) {
        Console.Write("Put your first number: ");
        int first = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("put your second number: ");
        int second = int.Parse(Console.ReadLine() ?? "0");

        for(int i=first; i<=second; i++) {
            int processed = i;
            int aCount = 0;
            while(processed != 0) {
                if(processed % 12 == 10) {
                    aCount++;
                }
                processed /= 12;
            }
            if(aCount == 2) {
                Console.WriteLine(i);
            }
        }
    }
}