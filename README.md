# ⚙️ Error Control Simulator - Blazor WebAssembly Demo

🚀 Một ứng dụng tương tác mô phỏng các **thuật toán kiểm soát lỗi** phổ biến trong mạng máy tính, xây dựng bằng **C# (.NET 8)** với **Blazor WebAssembly**.  
🧠 Dành cho sinh viên, giảng viên và lập trình viên yêu thích mạng máy tính — học lý thuyết đi đôi với thực hành.

![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-purple) 
![.NET](https://img.shields.io/badge/.NET-8-blue) 
![License](https://img.shields.io/github/license/hoangsnowy/ErrorControlBlazorDemo)

---

## 🌐 Try it Online

🎯 [Click để xem demo trực tiếp](https://hoangsnowy.github.io/ErrorControlBlazorDemo/)

---

## 📚 Tính năng nổi bật

| Thuật toán | Mô phỏng chi tiết | Kiểm lỗi | Truyền lại |
|------------|-------------------|----------|-------------|
| 🧮 **Parity Check** | Chẵn lẻ 1 chiều và 2 chiều | ✅ | ❌ |
| 🔁 **CRC** | Cho phép nhập G(x) tùy ý | ✅ | ❌ |
| 📥 **Stop-and-Wait ARQ** | Mô phỏng timeout, mất ACK | ✅ | ✅ |
| 📨 **Go-Back-N ARQ** | Gửi nhiều frame, truyền lại từ lỗi | ✅ | ✅ |
| 📤 **Selective Repeat ARQ** | Truyền lại đúng frame lỗi | ✅ | ✅ |

👉 Ngoài ra:  
- Hiển thị chi tiết từng bước xử lý của thuật toán  
- Giao diện trực quan, dễ dùng, dễ học  

---

## 🛠 Công nghệ sử dụng

- ⚙️ Blazor WebAssembly (.NET 8)
- 💻 C# / Razor Pages
- 🔄 GitHub Actions cho CI/CD
- 🌍 Triển khai trên GitHub Pages

---

## 🖥️ Hướng dẫn chạy thử cục bộ

```bash
git clone https://github.com/hoangsnowy/ErrorControlBlazorDemo.git
cd ErrorControlBlazorDemo
dotnet run --project ErrorControlBlazorDemo/ErrorControlBlazorDemo.csproj