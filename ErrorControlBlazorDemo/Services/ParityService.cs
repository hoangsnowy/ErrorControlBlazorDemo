
namespace ErrorControlBlazorDemo.Services;

public class ParityService
{
    public (bool ketQua, List<string> log) KiemTraMotChieu(string chuoi, bool odd)
    {
        var log = new List<string>();
        int count = 0;
        for (int i = 0; i < chuoi.Length; i++)
        {
            if (chuoi[i] == '1')
            {
                count++;
                log.Add($"Vị trí {i + 1}: '1' → tổng = {count}");
            }
            else
            {
                log.Add($"Vị trí {i + 1}: '0' → tổng giữ nguyên = {count}");
            }
        }

        log.Add($"Tổng số bit 1: {count}");
        bool hopLe = odd ? count % 2 == 1 : count % 2 == 0;
        log.Add($"Kiểu kiểm tra: {(odd ? "Odd Parity (lẻ)" : "Even Parity (chẵn)")}");
        log.Add(hopLe ? "✅ Dữ liệu hợp lệ." : "❌ Dữ liệu lỗi.");
        return (hopLe, log);
    }

    public List<string> KiemTraHaiChieu(string[] maTran)
    {
        var log = new List<string>();
        int rows = maTran.Length;
        int cols = maTran[0].Length;

        log.Add($"📐 Ma trận nhận được: {rows} hàng x {cols} cột");

        int errorRow = -1, errorCol = -1;

        for (int i = 0; i < rows; i++)
        {
            int count = maTran[i].Count(c => c == '1');
            log.Add($"Hàng {i + 1} có {count} bit 1 → {(count % 2 == 0 ? "OK" : "Lỗi")}");
            if (count % 2 != 0) errorRow = i;
        }

        for (int j = 0; j < cols; j++)
        {
            int count = 0;
            for (int i = 0; i < rows; i++)
                if (maTran[i][j] == '1') count++;

            log.Add($"Cột {j + 1} có {count} bit 1 → {(count % 2 == 0 ? "OK" : "Lỗi")}");
            if (count % 2 != 0) errorCol = j;
        }

        if (errorRow >= 0 && errorCol >= 0)
            log.Add($"❗ Lỗi phát hiện tại: Hàng {errorRow + 1}, Cột {errorCol + 1}");
        else if (errorRow >= 0 || errorCol >= 0)
            log.Add("⚠️ Có lỗi nhưng không xác định chính xác vị trí.");
        else
            log.Add("✅ Không phát hiện lỗi.");

        return log;
    }
}
