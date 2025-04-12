
namespace ErrorControlBlazorDemo.Services;

public class CrcService
{
    // Tính CRC từ chuỗi dữ liệu M và đa thức Gx
    public (string crc, List<string> log) TinhCRC(string data, string generator)
    {
        var log = new List<string>();
        string padded = data + new string('0', generator.Length - 1);
        log.Add($"Chuỗi dữ liệu M: {data}");
        log.Add($"Đa thức G(x): {generator}");
        log.Add($"M sau khi thêm 0 (M'): {padded}");

        string remainder = ChiaModulo2(padded, generator, log);
        string result = data + remainder;
        log.Add($"CRC: {remainder}");
        log.Add($"Chuỗi gửi đi (M + CRC): {result}");

        return (result, log);
    }

    // Kiểm tra xem chuỗi Y truyền đến có hợp lệ không với đa thức Gx
    public (bool hopLe, List<string> log) KiemTraCRC(string fullData, string generator)
    {
        var log = new List<string>();
        log.Add($"Chuỗi Y nhận được: {fullData}");
        log.Add($"Đa thức G(x): {generator}");

        string remainder = ChiaModulo2(fullData, generator, log);
        bool isValid = remainder.All(c => c == '0');
        log.Add($"Phần dư sau chia: {remainder}");
        log.Add(isValid ? "✅ CRC hợp lệ (phần dư = 0)" : "❌ CRC lỗi (phần dư ≠ 0)");

        return (isValid, log);
    }

    private string ChiaModulo2(string input, string divisor, List<string> log)
    {
        var result = input.ToCharArray();
        for (int i = 0; i <= input.Length - divisor.Length; i++)
        {
            if (result[i] == '1')
            {
                log.Add($"> Chia tại vị trí {i}: {new string(result[i..(i + divisor.Length)])} ⊕ {divisor}");
                for (int j = 0; j < divisor.Length; j++)
                {
                    result[i + j] = result[i + j] == divisor[j] ? '0' : '1';
                }
                log.Add($"  → Kết quả: {new string(result[i..(i + divisor.Length)])}");
            }
        }
        return new string(result[^ (divisor.Length - 1)..]);
    }
}
