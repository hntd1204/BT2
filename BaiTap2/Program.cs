using System;
using System.Collections.Generic;
using System.Linq;

class SinhVien
{
    private string maSoSinhVien;
    private string hoTen;
    private float diemTrungBinh;
    private string khoa;

    public string MaSoSinhVien { get => maSoSinhVien; set => maSoSinhVien = value; }
    public string HoTen { get => hoTen; set => hoTen = value; }
    public float DiemTrungBinh { get => diemTrungBinh; set => diemTrungBinh = value; }
    public string Khoa { get => khoa; set => khoa = value; }

    public SinhVien() { }

    public SinhVien(string maSoSinhVien, string hoTen, float diemTrungBinh, string khoa)
    {
        this.maSoSinhVien = maSoSinhVien;
        this.hoTen = hoTen;
        this.diemTrungBinh = diemTrungBinh;
        this.khoa = khoa;
    }

    public void NhapThongTin()
    {
        Console.Write("Nhập mã số sinh viên: ");
        MaSoSinhVien = Console.ReadLine();
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhập điểm trung bình: ");
        DiemTrungBinh = float.Parse(Console.ReadLine());
        Console.Write("Nhập khoa: ");
        Khoa = Console.ReadLine();
    }

    public void XuatThongTin()
    {
        Console.WriteLine($"MSSV: {MaSoSinhVien} - Họ tên: {HoTen} - Khoa: {Khoa} - Điểm TB: {DiemTrungBinh}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        bool thoat = false;

        while (!thoat)
        {
            Console.WriteLine("=== MENU QUẢN LÝ SINH VIÊN ===");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Hiển thị sinh viên khoa CNTT");
            Console.WriteLine("4. Hiển thị sinh viên có điểm TB >= 5");
            Console.WriteLine("5. Hiển thị danh sách sinh viên sắp xếp theo điểm TB tăng dần");
            Console.WriteLine("6. Hiển thị sinh viên khoa CNTT có điểm TB >= 5");
            Console.WriteLine("7. Hiển thị sinh viên có điểm TB cao nhất thuộc khoa CNTT");
            Console.WriteLine("8. Thống kê số lượng sinh viên theo xếp loại");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng (0-8): ");
            string luaChon = Console.ReadLine();

            switch (luaChon)
            {
                case "1":
                    ThemSinhVien(danhSachSinhVien);
                    break;
                case "2":
                    HienThiDanhSachSinhVien(danhSachSinhVien);
                    break;
                case "3":
                    HienThiSinhVienTheoKhoa(danhSachSinhVien, "CNTT");
                    break;
                case "4":
                    HienThiSinhVienDiemCao(danhSachSinhVien, 5);
                    break;
                case "5":
                    SapXepSinhVienTheoDiem(danhSachSinhVien);
                    break;
                case "6":
                    HienThiSinhVienTheoKhoaVaDiem(danhSachSinhVien, "CNTT", 5);
                    break;
                case "7":
                    HienThiSinhVienDiemCaoNhatTheoKhoa(danhSachSinhVien, "CNTT");
                    break;
                case "8":
                    ThongKeXepLoaiSinhVien(danhSachSinhVien);
                    break;
                case "0":
                    thoat = true;
                    Console.WriteLine("Kết thúc chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ThemSinhVien(List<SinhVien> danhSachSinhVien)
    {
        Console.WriteLine("=== Nhập thông tin sinh viên ===");
        SinhVien sinhVien = new SinhVien();
        sinhVien.NhapThongTin();
        danhSachSinhVien.Add(sinhVien);
        Console.WriteLine("Thêm sinh viên thành công!");
    }

    static void HienThiDanhSachSinhVien(List<SinhVien> danhSachSinhVien)
    {
        if (danhSachSinhVien.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên trống.");
        }
        else
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (SinhVien sinhVien in danhSachSinhVien)
            {
                sinhVien.XuatThongTin();
            }
        }
    }

    static void HienThiSinhVienTheoKhoa(List<SinhVien> danhSachSinhVien, string khoa)
    {
        Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} ===", khoa);
        var sinhVienKhoa = danhSachSinhVien.Where(s => s.Khoa.Equals(khoa, StringComparison.OrdinalIgnoreCase));
        foreach (var sinhVien in sinhVienKhoa)
        {
            sinhVien.XuatThongTin();
        }
    }

    static void HienThiSinhVienDiemCao(List<SinhVien> danhSachSinhVien, float diemTBToiThieu)
    {
        Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} ===", diemTBToiThieu);
        var sinhVienDiemCao = danhSachSinhVien.Where(s => s.DiemTrungBinh >= diemTBToiThieu);
        foreach (var sinhVien in sinhVienDiemCao)
        {
            sinhVien.XuatThongTin();
        }
    }

    static void SapXepSinhVienTheoDiem(List<SinhVien> danhSachSinhVien)
    {
        Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm TB tăng dần ===");
        var sinhVienSapXep = danhSachSinhVien.OrderBy(s => s.DiemTrungBinh).ToList();
        foreach (var sinhVien in sinhVienSapXep)
        {
            sinhVien.XuatThongTin();
        }
    }

    static void HienThiSinhVienTheoKhoaVaDiem(List<SinhVien> danhSachSinhVien, string khoa, float diemTBToiThieu)
    {
        Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1} ===", diemTBToiThieu, khoa);
        var sinhVienKhoaVaDiem = danhSachSinhVien.Where(s => s.DiemTrungBinh >= diemTBToiThieu && s.Khoa.Equals(khoa, StringComparison.OrdinalIgnoreCase));
        foreach (var sinhVien in sinhVienKhoaVaDiem)
        {
            sinhVien.XuatThongTin();
        }
    }

    static void HienThiSinhVienDiemCaoNhatTheoKhoa(List<SinhVien> danhSachSinhVien, string khoa)
    {
        Console.WriteLine("=== Danh sách sinh viên có điểm TB cao nhất và thuộc khoa {0} ===", khoa);
        var sinhVienKhoa = danhSachSinhVien.Where(s => s.Khoa.Equals(khoa, StringComparison.OrdinalIgnoreCase));
        float diemTBMax = sinhVienKhoa.Max(s => s.DiemTrungBinh);
        var sinhVienDiemCaoNhat = sinhVienKhoa.Where(s => s.DiemTrungBinh == diemTBMax).ToList();
        foreach (var sinhVien in sinhVienDiemCaoNhat)
        {
            sinhVien.XuatThongTin();
        }
    }

    static void ThongKeXepLoaiSinhVien(List<SinhVien> danhSachSinhVien)
    {
        Console.WriteLine("=== Thống kê số lượng sinh viên theo xếp loại ===");

        var thongKe = new Dictionary<string, int>
        {
            {"Xuất sắc", danhSachSinhVien.Count(s => s.DiemTrungBinh >= 9 && s.DiemTrungBinh <= 10)},
            {"Giỏi", danhSachSinhVien.Count(s => s.DiemTrungBinh >= 8 && s.DiemTrungBinh < 9)},
            {"Khá", danhSachSinhVien.Count(s => s.DiemTrungBinh >= 7 && s.DiemTrungBinh < 8)},
            {"Trung bình", danhSachSinhVien.Count(s => s.DiemTrungBinh >= 5 && s.DiemTrungBinh < 7)},
            {"Yếu", danhSachSinhVien.Count(s => s.DiemTrungBinh >= 4 && s.DiemTrungBinh < 5)},
            {"Kém", danhSachSinhVien.Count(s => s.DiemTrungBinh < 4)}
        };

        foreach (var xepLoai in thongKe)
        {
            Console.WriteLine($"{xepLoai.Key}: {xepLoai.Value} sinh viên");
        }
    }
}
