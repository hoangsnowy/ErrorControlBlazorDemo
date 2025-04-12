# 🔧 Dự án Demo Kiểm Soát Lỗi trong Mạng Máy Tính (Blazor WebAssembly)

Đây là ứng dụng demo mô phỏng các **thuật toán kiểm soát lỗi** thường gặp trong mạng máy tính.  
Dự án được xây dựng bằng **C#**, **.NET 8** và **Blazor WebAssembly** — chạy trực tiếp trên trình duyệt, không cần cài đặt.

---

## 🌐 Truy cập ứng dụng

👉 [Xem demo tại đây](https://hoangsnowy.github.io/ErrorControlBlazorDemo/)

---

## ✅ Các tính năng

- 🧮 **Kiểm tra chẵn lẻ (Parity Check)**: cả Even và Odd
- 🔁 **CRC (Cyclic Redundancy Check)**: cho phép nhập đa thức G(x) tùy ý
- 🔄 **Giao thức ARQ**:
  - Stop-and-Wait
  - Go-Back-N
  - Selective Repeat
- 👁️ Hiển thị từng bước xử lý của từng thuật toán để dễ học
- 🧠 Giao diện trực quan, dễ sử dụng cho người mới học

---

## ⚙️ Công nghệ sử dụng

- Blazor WebAssembly (.NET 8)
- C# / Razor
- GitHub Actions CI/CD
- GitHub Pages để triển khai online

---

## 🛠️ Chạy thử trên máy tính cá nhân

```bash
git clone https://github.com/hoangsnowy/ErrorControlBlazorDemo.git
cd ErrorControlBlazorDemo
dotnet run --project ErrorControlBlazorDemo/ErrorControlBlazorDemo.csproj