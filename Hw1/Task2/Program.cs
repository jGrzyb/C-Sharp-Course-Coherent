Console.Write("Put your nine digit code: ");
string input = Console.ReadLine() ?? "000000000";
int sum = 0;
for(int i=0; i<input.Length; i++) {
    sum += (i+1) * (input[i] - '0');
}
string result = "";
if(sum % 11 == 0) {
    result = input + '0';
}
else if(sum % 11 == 1) {
    result = input + 'X';
}
else {
    result = input + (11 - sum % 11);
}
Console.WriteLine(result);